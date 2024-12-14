using System;
using System.IO;
using System.Linq;
using System.Drawing;

using DocTerraRestApiLib;
using DocTerraRestApiLib.Classes;
using ModifyImagesBorder;

namespace DocTerraRestApi_Example_ModifyImagesBorder
{
    
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            InputArgs input_data;
#if DEBUG
            input_data = new InputArgs("project-nbim-sdk/articles");
            input_data.BorderSize = 2;
            args = new string[] { "project-nbim-sdk/articles", "*.jpg", "0;0;0", "2" };
#else
            input_data = new InputArgs(args[0]);
            input_data.ImageExtension = args[1];
            int[] color_def = args[2].Split(';').Select(a => int.Parse(a)).ToArray();
            input_data.Color = Color.FromArgb(color_def[0], color_def[1], color_def[2]);
            input_data.BorderSize = int.Parse(args[3]);
#endif
            Color t_color = input_data.Color ?? InputArgs.ColorBlack;
            DTerra_Connection connection = new DTerra_Connection();
            DTerra_ApiProcedures dTerra_ApiActions = new DTerra_ApiProcedures(connection);

            var files_at_project = dTerra_ApiActions.GetFilesInfoFromStorage(args[0], args[1], true);
            if (files_at_project == null) return;

            foreach (Storage_FileInfo? file_at_project_Info in files_at_project)
            {
                //делаем дополнительный запрос, т.к. стандартный GetFilesInfoFromStorage не возвращает content у файлов
                Storage_FileInfo? file_at_project_Info2 = dTerra_ApiActions.GetFileInfoFromStorage(file_at_project_Info.GetFileFullNameWithoutStorage());
                string temp_image_path = Path.GetTempFileName(); //  Path.Combine(savePath, Guid.NewGuid().ToString() + Path.GetExtension(file_at_project_Info2?.fileName ?? ".jpg"));
                //temp_image_path = temp_image_path.Replace(Path.GetExtension(temp_image_path), Path.GetExtension(file_at_project_Info2?.fileName ?? ".jpg"));

                file_at_project_Info2?.ToFile(temp_image_path);
                if (File.Exists(temp_image_path))
                {
                    Bitmap image = new Bitmap(temp_image_path);
                    //Сперва нужно проверить, какие поля у снимка -- на какую длину, начиная итеративно с рамок по 1 пиксель
                    int border_size = 1;
                    while (CheckBorder(border_size))
                    {
                        border_size++;
                    }
                    //border_size -= 1;

                   
                    if (border_size != input_data.BorderSize)
                    {
                        Bitmap? imageNew = null;
                        //int[][] new_raster_def = new int[1][];
                        //Нужно создать новый растр с размерами больше или меньше на недостающее число полей
                        //Сперва определим, нужно будет его уменьшать или увеличивать
                        if (border_size > input_data.BorderSize)
                        {
                            int reduceStep = border_size - input_data.BorderSize;
                            imageNew = new Bitmap(image.Width - 2 * reduceStep, image.Height - 2 * reduceStep);
                            //нужно уменьшить
                            //new_raster_def = new int[image.Width - (border_size - image_border)][];
                            for (int width_c = reduceStep; width_c < image.Width - reduceStep; width_c++)
                            {
                               for (int height_c = reduceStep; height_c < image.Height - reduceStep; height_c++)
                               {
                                    imageNew.SetPixel(width_c - reduceStep, height_c - reduceStep, image.GetPixel(width_c, height_c));
                               }
                            }
                        }
                        else if (border_size < input_data.BorderSize)
                        {
                            int increaseStep = input_data.BorderSize - border_size;
                            //сперва нужно запомнить новый растр черными полями, а потом перенести данные из оригинального растра
                            imageNew = new Bitmap(image.Width + 2 * increaseStep, image.Height + 2 * increaseStep);

                            //Простановка в нижней и верхней горизонтальных границах изображения
                            for (int width_c = 0; width_c < imageNew.Width; width_c++)
                            {
                                for (int height_c = 0; height_c <= increaseStep; height_c++)
                                {
                                    imageNew.SetPixel(width_c, height_c, t_color);
                                    imageNew.SetPixel(width_c, imageNew.Height - height_c - 1, t_color);
                                }
                            }

                            //Проверка левой и правой вертикальных границ растра
                            for (int height_c = 0; height_c < imageNew.Height; height_c++)
                            {
                                for (int width_c = 0; width_c <= increaseStep; width_c++)
                                {
                                    imageNew.SetPixel(width_c, height_c, t_color);
                                    imageNew.SetPixel(imageNew.Width - width_c - 1, height_c, t_color);
                                }
                            }

                            //Копирование всего остального изображения
                            for (int width_c = 0; width_c < image.Width; width_c++)
                            {
                                for (int height_c = 0; height_c < image.Height; height_c++)
                                {
                                    imageNew.SetPixel(width_c + increaseStep, height_c + increaseStep, image.GetPixel(width_c, height_c));
                                }
                            }
                        }

                        string temp_image_path2 = temp_image_path.Replace(Path.GetFileName(temp_image_path), Guid.NewGuid().ToString("N") + Path.GetExtension(temp_image_path));
                        if (imageNew !=null) 
                        {
                            imageNew.Save(temp_image_path2);
                            string image_content = Storage_FileInfo.GetFileContent(temp_image_path2);
                            Storage_FileOrFolderCreation_Info fileInfo = new Storage_FileOrFolderCreation_Info(image_content, false);
                            //dTerra_ApiActions.CreateFileOrFolder(file_at_project_Info.GetFileFullNameWithoutStorage(), DocTerraRestApiLib.Enumerations.FormatVariant.base64, true, fileInfo);
                            Storage_FileUpdateInfo file_at_project_Info_Upd = new Storage_FileUpdateInfo(image_content);
                            dTerra_ApiActions.UpdateFileInStorage(file_at_project_Info.GetFileFullNameWithoutStorage(), file_at_project_Info_Upd);
                        }


                    }


                    bool CheckBorder(int offset)
                    {
                        //идея метода -- проверка каждой из четыерех сторон картинки на ширину 1px, равны ли цвета заданному t_color
                        bool is_color = true;

                        //Проверка нижней и верхней горизонтальных границ изображения
                        for (int width_c = offset; width_c < image.Width - offset; width_c++)
                        {
                            var pixel_info_bottom = image.GetPixel(width_c, offset);
                            var pixel_info_top = image.GetPixel(width_c, image.Height - offset);
                            if (pixel_info_bottom != t_color) { is_color = false; break; }
                            if (pixel_info_top != t_color) { is_color = false; break; }
                        }

                        //Проверка левой и правой вертикальных границ растра
                        for (int height_c = offset; height_c < image.Height - offset; height_c++)
                        {
                            var pixel_info_left = image.GetPixel(offset, height_c);
                            var pixel_info_right = image.GetPixel(image.Width - offset, height_c);
                            if (pixel_info_left != t_color) { is_color = false; break; }
                            if (pixel_info_right != t_color) { is_color = false; break; }
                        }
                        return is_color;
                    }
                }

            }
            //string oneFileInfo = files_at_project[1].GetFileFullNameWithoutStorage();
            //var file_data_at_project = dTerra_ApiActions.GetFileInfoFromStorage(oneFileInfo);
            Console.WriteLine("\nEnd!");
            Console.ReadKey();
        }
    }
}
