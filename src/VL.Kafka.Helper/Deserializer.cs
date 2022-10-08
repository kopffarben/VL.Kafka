using Confluent.Kafka;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VL.Core;

namespace VL.Kafka.Helper
{
    public class Deserializer<TValue> : IDeserializer<TValue> where TValue : class
    {
        string recordName;
        Func<string, TValue> deserialize;

        public Deserializer(Func<string, TValue> deserialize)
        {
            this.recordName = VLFactory.Current.GetTypeInfo(typeof(TValue)).Name;
            this.deserialize = deserialize;
        }

        public TValue Deserialize(ReadOnlySpan<byte> data, bool isNull, Confluent.Kafka.SerializationContext context) 
        {
            if (isNull)
            {
                return null;
            }
            else
            {
                try
                {
                    var array = data.ToArray();
                    using (var stream = new MemoryStream(array, 0, array.Length))
                    using (var sr = new System.IO.StreamReader(stream, Encoding.UTF8))
                    {
                        return deserialize.Invoke(sr.ReadToEnd());
                    }
                }
                catch (AggregateException e)
                {
                    throw e.InnerException;
                }
            }
        }
    }

    public class AsyncDeserializer<TValue> : IAsyncDeserializer<TValue> where TValue : class
    {
        private readonly int headerSize = sizeof(int) + sizeof(byte);
        private const byte MagicByte = 0;

        string recordName;
        Func<string, TValue> deserialize;

        public AsyncDeserializer(Func<string, TValue> deserialize)
        {
            this.recordName = VLFactory.Current.GetTypeInfo(typeof(TValue)).Name;
            this.deserialize = deserialize;
        }

        public Task<TValue> DeserializeAsync(ReadOnlyMemory<byte> data, bool isNull, Confluent.Kafka.SerializationContext context)
        {
            if (isNull) 
            { 
                return Task.FromResult<TValue>(null); 
            }
            else
            {
                try
                {
                    var array = data.ToArray();
                    using (var stream = new MemoryStream(array, 0, array.Length))
                    using (var sr = new System.IO.StreamReader(stream, Encoding.UTF8))
                    {
                        return Task.FromResult(deserialize.Invoke(sr.ReadToEnd()));
                    }
                }
                catch (AggregateException e)
                {
                    throw e.InnerException;
                }
            } 
        }
    }

    
}
