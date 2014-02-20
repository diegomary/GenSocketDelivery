using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GenericSocketHelper
{
    public class ByteHelper:IDisposable
    {
        private bool disposed = false;

        public byte[] GenericToByteArray<T>(T obj) where T:class // To prevent integral type to be passed in the method
        {
            if (obj == null) return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();           
        }
        public object ByteArrayToGeneric<T>(byte[] arrBytes) 
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            T obj = (T)binForm.Deserialize(memStream);
            return obj;
        }

        public void SaveByteArrayToFile(byte[] myarray,string filepath)
        {
            using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(myarray, 0, myarray.Length);
            }
        }

        public byte[] LoadByteArrayFromFile(string filepath)
        {
            byte[] result = null;
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                result = new byte[fs.Length];
                int nbytes= fs.Read(result, 0, result.Length );
            }
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                   // CleanUp
                }

                disposed = true;
            }
        }
  
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);         
        }
         ~ ByteHelper()
        { 
             //For unmanaged resources

        }

    }
}
