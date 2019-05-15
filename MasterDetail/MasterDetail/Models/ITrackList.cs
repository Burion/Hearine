
using System.Collections.Generic;
namespace MasterDetail.Models
{
    public interface ITrackList
    {
        string Band { get; set; }
        string Name { get; set; }
        string Image { get; set; }
        List<StrippedTrackElement> Tracks { get; set; }
    }
}
