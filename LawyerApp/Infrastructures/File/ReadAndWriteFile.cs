using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using useFile = System.IO;
namespace LawyerApp.Infrastructures.File
{
    public static class ReadAndWriteFile
    {
        public async static Task<T> ReadFileAsync<T>(string path)
        {
            string data;
            using (FileStream str = useFile.File.OpenRead(path))
            {
                using (StreamReader read = new StreamReader(str))
                {
                    data = await read.ReadToEndAsync();
                }
            }
            return JsonConvert.DeserializeObject<T>(data);
        }

        public async static Task WriteFileAsync<T>(T obj, string path)
        {
            using (FileStream str = useFile.File.Create(path))
            {
                using (BufferedStream bstream = new BufferedStream(str))
                {
                    using (StreamWriter writer = new StreamWriter(bstream))
                    {
                        await writer.WriteAsync(JsonConvert.SerializeObject(obj));
                    }
                }
            }
        }
    }
}
