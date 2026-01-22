using System.ComponentModel.DataAnnotations;

namespace BlazorMovieApp.Models;

public class Movies
{
	public int Id { set; get; }
	public String? Title { set; get; }
	[DataType(DataType.Date)]
	public DateTime? ReleaseDate { set; get; }
	public String? Genre { set; get; }
	public decimal Price { set; get; }
}