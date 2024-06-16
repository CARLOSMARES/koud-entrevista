﻿using System;

using System.ComponentModel.DataAnnotations;

namespace tvshow.Models
{
	public class TvShow
	{

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string? Name { get; set; }

		public bool Favorite { get; set; }

	}
}

