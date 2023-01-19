namespace Juan.Helpers
{
    public class FileManage
    {
        public static string SaveFile(string rootpath, string FolderName, IFormFile file)
        {
            string name = file.FileName;

            if (name.Length > 136)
            {
                name.Substring(name.Length - 100, 100);
            }
            name = Guid.NewGuid().ToString() + name;


            string paths = Path.Combine(rootpath, FolderName, file.FileName);


            using (FileStream fs = new FileStream(paths, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return name;
        }

        public static void DeletFile(string rootPath,string FolderName, string fileName)
        { 
            string deletePath = Path.Combine(rootPath, FolderName, fileName);
            if (System.IO.File.Exists(deletePath))
            {
                System.IO.File.Delete(deletePath);
            }
        
        }
    }
}
