using Newtonsoft.Json;
using System.IO;

namespace ContactsAppBL
{
    /// <summary>
    /// Менеджер проекта.
    /// </summary>
        public static class ProjectManager
        {
            /// <summary>
            /// Сериалайзер.
            /// </summary>
            private static readonly JsonSerializer JsonSerializer = new JsonSerializer();

            /// <summary>
            /// Cохраняет проект в файл.
            /// </summary>
            /// <param name="project">Проект.</param>
            public static void SaveToFile(Project project, string _pathToFile)
            {
                using (var streamWriter = new StreamWriter(_pathToFile))
                using (var jsonWriter = new JsonTextWriter(streamWriter))
                {
                    JsonSerializer.Serialize(jsonWriter, project);
                }
            }

        /// <summary>
        /// Загружает проект из файла.
        /// </summary>
        /// <returns>Проект.</returns>
        public static Project LoadFromFile(string _pathToFile)
        {
            if (!File.Exists(_pathToFile))
            {
                return null;
            }

            using (var streamReader = new StreamReader(_pathToFile))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return JsonSerializer.Deserialize<Project>(jsonReader);
            }
        }
    }
}
