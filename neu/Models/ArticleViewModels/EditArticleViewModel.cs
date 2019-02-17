﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace neu.Models.ArticleViewModels
{
    public class EditArticleViewModel
    {
        [MaxLength(50)]
        public string Title { get; set; }

        public string Content { get; set; }

        [MaxLength(100)]
        public string Subtitle { get; set; }
    }
}