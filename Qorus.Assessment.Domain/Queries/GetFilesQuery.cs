using Qorus.Assessment.Domain.Dto;
using System.Collections.Generic;

namespace Qorus.Assessment.Domain.Queries
{
    public class GetFilesQuery : Query<List<FileDto>>
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}
