using FakeFlix.Models;
using FakeFlix.Utilities.Utilities;
using Sitecore.Data.Fields;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Collections;

namespace FakeFlix.Repositories
{
    public class ProductListingRepository
    {
        public JsonResult GetProductListingData(string DataSourceId, string ITEM__ID)
        {

            Database dataBase = Sitecore.Configuration.Factory.GetDatabase(Sitecore.Context.Database.Name);
            Item pageItem = dataBase.GetItem(new ID(ITEM__ID));
            ProductListingModel model = new ProductListingModel();
            List<MovieListingItems> movieListingItems = new List<MovieListingItems>();
            FieldConverter fieldConverter = new FieldConverter();
            try
            {
                if (DataSourceId == null)
                {
                    return new JsonResult()
                    {
                        Data = "Datasource ID is null! Provide a Datasource",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                if (pageItem == null)
                {
                    return new JsonResult()
                    {
                        Data = "Page ID is null! Provide a PageId",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }

                if (dataBase == null)
                {
                    return new JsonResult()
                    {
                        Data = "Failed to retrieve the Context DB!",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                Item listingDetails = dataBase.GetItem(DataSourceId);
                if (listingDetails != null)
                {
                    model.ProductListingTitle = listingDetails["ProductListingTitle"];
                }

                IEnumerable<Item> ChildItems = pageItem.GetChildren();
                foreach (Item childItems in ChildItems)
                {
                    foreach (Item grandChildren in childItems.Children)
                    {
                        if (grandChildren != null)
                        {
                            CheckboxField isChecked = grandChildren.Fields["isNew"];
                            if (isChecked == null)
                            {
                                return new JsonResult()
                                {
                                    Data = "checkbox grandChildren field is null! Provide the correct grandChildren field!",
                                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                };
                            }

                            Field dateTimeField = grandChildren.Fields["CurrentDateTime"];
                            if (dateTimeField == null)
                            {
                                return new JsonResult()
                                {
                                    Data = "DateTime is Null!",
                                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                };
                            }
                            string TimeZoneID = "India Standard Time";
                            TimeZoneInfo ISTTimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneID);
                            System.DateTime dateTimeValue = ((DateField)dateTimeField).DateTime;
                            System.DateTime lastCheckDateTime = TimeZoneInfo.ConvertTime(dateTimeValue, ISTTimeZone);
                            System.DateTime currentTime = System.DateTime.Now;
                            System.DateTime checkedTimestamp = isChecked.Checked ? lastCheckDateTime : System.DateTime.MinValue;
                            int duration = Int32.Parse(grandChildren["TagDuration"]);
                            TimeSpan timeLimit = TimeSpan.FromMinutes(duration);
                            bool isMovieNew = (currentTime - checkedTimestamp) >= timeLimit;
                            MovieListingItems movieListgrandChildrens = new MovieListingItems()
                            {
                                ProductGenreName = childItems.Name,
                                MovieTitle = grandChildren["MovieTitle"],
                                MovieCTALink = fieldConverter.GetLinkUrl(grandChildren),
                                MovieCTAText = grandChildren["MovieCTAText"],
                                MoviePoster = fieldConverter.GetImageUrl(grandChildren, "MovieImage"),
                                DescTextTitle = grandChildren["StarringCastsTitle"],
                                DescMultiLineText = grandChildren["StarringCast"],
                                IsMovieNew = !isMovieNew,
                                CurrentDateTime = currentTime.ToString(),
                                CheckedDateTime = lastCheckDateTime.ToString(),
                            };
                            movieListingItems.Add(movieListgrandChildrens);
                        }
                    }
                }
                model.ProductListingItems = movieListingItems;

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