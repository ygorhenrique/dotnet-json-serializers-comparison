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
    public class NewtonsoftValueTests : IDisposable
    {
        private readonly string resourceName = $"NewtonsoftAsserts.Person.json";
        private Stream stream;
        private StreamReader streamReader;

        public NewtonsoftValueTests()
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
            var PersonValue =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.DefaultConstructors.PersonValue>(await streamReader.ReadToEndAsync());

            Assert.NotNull(PersonValue);
            Assert.Equal("Clark", PersonValue.FirstName);
            Assert.Equal("Kent", PersonValue.LastName);
            Assert.Equal(new DateTime(1997, 04, 18), PersonValue.DateOfBirth);
        }

        // Interesting enough, structs can have multiple constructors and still be deserialized correctly
        [Fact]
        public async Task ShouldDeserializeUsing_MultipleConstructors()
        {
            var PersonValue =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.ExplicitMultipleConstructors.PersonValue>(await streamReader.ReadToEndAsync());

            Assert.NotNull(PersonValue);
            Assert.Equal("Clark", PersonValue.FirstName);
            Assert.Equal("Kent", PersonValue.LastName);
            Assert.Equal(new DateTime(1997, 04, 18), PersonValue.DateOfBirth);
        }

        [Fact]
        public async Task ShouldDeserializeUsing_ExplicitConstructors()
        {
            var PersonValue =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.ExplicitConstructors.PersonValue>(await streamReader.ReadToEndAsync());

            Assert.NotNull(PersonValue);
            Assert.Equal("Clark", PersonValue.FirstName);
            Assert.Equal("Kent", PersonValue.LastName);
            Assert.Equal(new DateTime(1997, 04, 18), PersonValue.DateOfBirth);
        }

        [Fact]
        public async Task StructsCannotHave_Parameterless_PrivateConstructors()
        {
            Assert.True(true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UnableToDeserialize_PrivateConstructorsReadOnly()
        {
            var PersonValue =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.PrivateConstructorsReadOnly.PersonValue>(await streamReader.ReadToEndAsync());

            Assert.NotNull(PersonValue);
            Assert.Null(PersonValue.FirstName);
            Assert.Null(PersonValue.LastName);
            Assert.Null(PersonValue.DateOfBirth);
        }
    }
}