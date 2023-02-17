using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamRecords
{
    public class VertexConverter : JsonConverter<ImgVertex>
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;

        public override ImgVertex ReadJson(JsonReader reader, Type objectType, ImgVertex existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            var vertex = (ImgVertex)default(Vertex);
            switch (jsonObject.Value<Int64>("VertexType"))
            {
                case -1:
                    vertex = new Counter();
                    break;
                case 0:
                    vertex = new Answer();
                    break;
                case 1:
                    vertex = new Category();
                    break;
                case 2:
                    vertex = new Question();
                    break;
                case 3:
                    vertex = new Keyword();
                    break;
            }
            serializer.Populate(jsonObject.CreateReader(), vertex);
            return vertex;
        }

        public override void WriteJson(JsonWriter writer, ImgVertex value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
