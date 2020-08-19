using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Entities.DefaultConstructors;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace NewtonsoftAsserts
{
    public class NewtonsoftTests : IDisposable
    {
        private readonly string resourceName = $"NewtonsoftAsserts.Person.json";
        private Stream stream;
        private StreamReader streamReader;

        public NewtonsoftTests()
        {
            stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(resourceName); ;

            streamReader = new StreamReader(stream);
        }

        public void Dispose()
        {
            streamReader.Dispose();
            stream.Dispose();
        }

        [Fact]
        public async Task ShouldDeserializeUsing_DefaultConstructors()
        {
            var person =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.DefaultConstructors.Person>(await streamReader.ReadToEndAsync());

            Assert.NotNull(person);
            Assert.Equal("Clark", person.FirstName);
            Assert.Equal("Kent", person.LastName);
            Assert.Equal(new DateTime(1997, 04, 18), person.DateOfBirth);
        }

        [Fact]
        public async Task ShouldThrowJsonSerializationExceptionWhenUsing_MultipleConstructors()
        {
            var str = await streamReader.ReadToEndAsync();
            Assert.Throws<JsonSerializationException>(()
                => Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.ExplicitMultipleConstructors.Person>(str));
        }

        [Fact]
        public async Task ShouldDeserializeUsing_ExplicitConstructors()
        {
            var person =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.ExplicitConstructors.Person>(await streamReader.ReadToEndAsync());

            Assert.NotNull(person);
            Assert.Equal("Clark", person.FirstName);
            Assert.Equal("Kent", person.LastName);
            Assert.Equal(new DateTime(1997, 04, 18), person.DateOfBirth);
        }

        [Fact]
        public async Task ShouldDeserializeUsing_PrivateConstructors()
        {
            var person =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.PrivateConstructors.Person>(await streamReader.ReadToEndAsync());

            Assert.NotNull(person);
            Assert.Equal("Clark", person.FirstName);
            Assert.Equal("Kent", person.LastName);
            Assert.Equal(new DateTime(1997, 04, 18), person.DateOfBirth);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UnableToDeserialize_PrivateConstructorsReadOnly()
        {
            var person =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.PrivateConstructorsReadOnly.Person>(await streamReader.ReadToEndAsync());

            Assert.NotNull(person);
            Assert.Null(person.FirstName);
            Assert.Null(person.LastName);
            Assert.Null(person.DateOfBirth);
        }
    }
}