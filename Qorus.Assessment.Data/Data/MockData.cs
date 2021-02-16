using Qorus.Assessment.Data.Contexts;
using Qorus.Assessment.Domain.Models;
using System;

namespace Qorus.Assessment.Data.Data
{
    public class MockData
    {
        public static File FakeFile1 { get; } =
            new File
            {
                Id = Guid.NewGuid(),
                Name = "File1",
                Category = "Test",
                Size = 300,
                LastReviewed = DateTime.Now,
                URL = @"https://s2.glbimg.com/3cbcYz2Vy0qQG2-_y87RARlVnVM=/0x0:620x413/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_cf9d035bf26b4646b105bd958f32089d/internal_photos/bs/2020/2/9/kUgT73SAawl5udid0DPA/2019-03-30-f-.jpg"
            };

        public static File FakeFile2 { get; } =
           new File
           {
               Id = Guid.NewGuid(),
               Name = "File2",
               Category = "Tes2",
               Size = 300,
               LastReviewed = DateTime.Now,
               URL = @"https://s2.glbimg.com/3cbcYz2Vy0qQG2-_y87RARlVnVM=/0x0:620x413/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_cf9d035bf26b4646b105bd958f32089d/internal_photos/bs/2020/2/9/kUgT73SAawl5udid0DPA/2019-03-30-f-.jpg"
           };

        public static void SeedTestData(SqlContext context)
        {
            context.Files.Add(FakeFile1);
            context.Files.Add(FakeFile2);

            context.SaveChanges();
        }
    }
}
