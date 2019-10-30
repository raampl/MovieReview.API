using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.API.Domain.Models
{
    public enum EGenre
    {
        [Description("ACTION")]
        Action = 1,

        [Description("HORROR")]
        Horror = 2,

        [Description("COMEDY")]
        Comedy = 3,

        [Description("DOCUMENTORY")]
        Documentary = 4,

        [Description("THRILLER")]
        Thriller = 5,

        [Description("DRAMA")]
        Drama = 6
    }
}
