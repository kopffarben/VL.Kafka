using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Kafka.Helper
{
    public class Serializer<TValue> : ISerializer<TValue>
    {
        Func<TValue, string> serialize;

        public Serializer(Func<TValue, string> serialize)
        {
            this.serialize = serialize;
        }

        public byte[] Serialize(TValue data, SerializationContext context)
        {
            string ser = serialize.Invoke(data);
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetByteCount(ser)))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(System.Text.Encoding.UTF8.GetBytes(ser));
                return stream.ToArray();
            }
        }
    }

    public class AsyncSerializer<TValue> : IAsyncSerializer<TValue>
    {
        Func<TValue, string> serialize;

        public AsyncSerializer(Func<TValue, string> serialize)
        {
            this.serialize = serialize;
        }

        public Task<byte[]> SerializeAsync(TValue data, SerializationContext context)
        {
            string ser = serialize.Invoke(data);
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetByteCount(ser)))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(System.Text.Encoding.UTF8.GetBytes(ser));
                return Task.FromResult(stream.ToArray());
            }
        }
    }
}
