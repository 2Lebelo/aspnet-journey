using System.ComponentModel.DataAnnotations;

namespace BlazorMovieApp.Models;

public class Movies
{
	public int Id { set; get; }
	[Required]
	public String? Title { set; get; }
	[DataType(DataType.Date)]
	public DateTime? ReleaseDate { set; get; }
	public String? Genre { set; get; }
	[Range(1, 100)]
	public decimal Price { set; get; }
}