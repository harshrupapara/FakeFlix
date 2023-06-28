using FakeFlix.Models;
using FakeFlix.Utilities.Utilities;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Shell.Applications.ContentEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FakeFlix.Repositories
{
    public class MovieListingRepository
    {
        public JsonResult GetMoviesListingData(string DataSourceId, string PageId)
        {
            MovieListingModel model = new MovieListingModel();
            List<MovieListingItems> movieListingItems = new List<MovieListingItems>();
            FieldConverter fieldConverter = new FieldConverter();
            try
            {
                if(DataSourceId == null)
                {
                    return new JsonResult()
                    {
                        Data = "Datasource ID is null! Provide a Datasource",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                if (PageId == null)
                {
                    return new JsonResult()
                    {
                        Data = "Page ID is null! Provide a PageId",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                Database dataBase = Sitecore.Configuration.Factory.GetDatabase(Sitecore.Context.Database.Name);

                if(dataBase == null)
                {
                    return new JsonResult()
                    {
                        Data = "Failed to retrieve the Context DB!",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                Item listingDetails = dataBase.GetItem(DataSourceId);
                Item pageItem = dataBase.GetItem(PageId);
                
                
                if(listingDetails != null)
                {
                    model.MovieListingTitle = listingDetails["MovieListingTitle"];
                }
                if(pageItem!= null && pageItem.HasChildren)
                {
                    model.MovieGenreName = pageItem.Name;
                    foreach(Item item in pageItem.Children)
                    {
                        CheckboxField isChecked = item.Fields["isNew"];
                        if(isChecked == null)
                        {
                            return new JsonResult()
                            {
                                Data = "checkbox item field is null! Provide the correct item field!",
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                        }

                        Field dateTimeField = item.Fields["CurrentDateTime"];
                        if(dateTimeField == null)
                        {
                            return new JsonResult()
                            {
                                Data = "DateTime is Null!",
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                        }
                        string TimeZoneID = "India Standard Time";
                        TimeZoneInfo ISTTimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneID);
                        System.DateTime dateTimeValue= ((DateField)dateTimeField).DateTime;
                        System.DateTime lastCheckDateTime = TimeZoneInfo.ConvertTime(dateTimeValue, ISTTimeZone);
                        System.DateTime currentTime = System.DateTime.Now;
                        System.DateTime checkedTimestamp = isChecked.Checked ? lastCheckDateTime : System.DateTime.MinValue;
                        int duration = Int32.Parse(item["TagDuration"]);
                        TimeSpan timeLimit = TimeSpan.FromMinutes(duration);
                        bool isMovieNew = (currentTime - checkedTimestamp) >= timeLimit;
                        MovieListingItems movieListItems = new MovieListingItems()
                        {
                            MovieTitle = item["MovieTitle"],
                            MovieCTALink = fieldConverter.GetLinkUrl(item),
                            MovieCTAText = item["MovieCTAText"],
                            MoviePoster = fieldConverter.GetImageUrl(item, "MovieImage"),
                            IsMovieNew = !isMovieNew,
                            CurrentDateTime = currentTime.ToString(),
                            CheckedDateTime = lastCheckDateTime.ToString(),
                            CheckTimeStamp = checkedTimestamp.ToString(),
                        };
                        movieListingItems.Add(movieListItems);
                    }
                    model.MovieList = movieListingItems;
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error($"{System.DateTime.Now.ToShortTimeString()}  Error:{ex.Message}", this);
                return new JsonResult()
                {
                    Data = ex.Message,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

            return new JsonResult()
            {
                Data = model,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}