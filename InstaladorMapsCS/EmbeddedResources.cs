using System.IO;
using System.Linq;
using System.Reflection;

namespace InstaladorMapsCS
{
    class EmbeddedResources
    {
        private static Assembly executingAssembly;

        /// <summary>
        /// Obtém a path de todos os arquivos a partir de uma determinada pasta dentro do projeto
        /// </summary>
        /// <param name="folders">Pasta pai</param>
        /// <param name="extension">Extesão se houver</param>
        /// <returns></returns>
        public static string[] getResourceLocationFiles(string folders, string extension = "")
        {
            executingAssembly = Assembly.GetExecutingAssembly();
            string folderName = string.Format("{0}.{1}", executingAssembly.GetName().Name, folders);
            return executingAssembly
                .GetManifestResourceNames()
                .Where(r => r.StartsWith(folderName) && r.EndsWith(extension))
                .ToArray();
        }

        public static string[] getNameItemsFromPath(string folder) {
            executingAssembly = Assembly.GetExecutingAssembly();
            string folderName = string.Format("{0}.{1}", executingAssembly.GetName().Name, folder);
            return getResourceLocationFiles(folder).Select(r => r.Substring(folderName.Length + 1)).ToArray() ;

        }

        /// <summary>
        /// /Extrai os arquivos do projeto e salva em um local.
        /// </summary>
        /// <param name="FullPathOutput">String completa do arquivo a ser salvo</param>
        /// <param name="resourceLocation">Localizacao do arquivo no projeto</param>
        public static void ExtractEmbeddedResource(string FullPathOutput, string resourceLocation)
        {
            string pastas = Path.GetDirectoryName(FullPathOutput);
            if (!Directory.Exists(pastas)) {
                Directory.CreateDirectory(pastas);
            }

            using (FileStream fileStream = File.Create(FullPathOutput))
            {
                Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceLocation).CopyTo(fileStream);               
            }
        }

        /// <summary>
        /// Retorna o diretório das pastas e subpastas. Ex: resourceLocation: myprojectName.images.profile.caio.png, output: images\profile\caio.png
        /// </summary>
        /// <param name="EmbeddedResourscesPath"></param>
        /// <returns></returns>
        public static string transformStringPathEmbeddedResourcesInDirectories(string EmbeddedResourscesPath)
        {
            //separa a extensao do arquivo
            string extension = EmbeddedResourscesPath.Substring(EmbeddedResourscesPath.LastIndexOf('.'));
            string newpath = EmbeddedResourscesPath.Substring(0, EmbeddedResourscesPath.LastIndexOf('.'));
            //remove o nome do projeto
            newpath = newpath.Remove(0, Assembly.GetExecutingAssembly().GetName().Name.Length + 1);
            //subistitiu os pontos por barras para usar a string como pasta de destino
            newpath = newpath.Replace('.', '\\');
            //coloca a extensao devolta
            newpath = newpath + extension;

            return newpath;
        }


    }
}
/*
    reference:
    https://stackoverflow.com/questions/13031778/how-can-i-extract-a-file-from-an-embedded-resource-and-save-it-to-disk
    https://www.codeproject.com/Questions/436046/How-to-copy-files-from-resources-to-another-direct
    https://pt.stackoverflow.com/questions/4513/como-esconder-imagens-da-pasta-resources
*/
