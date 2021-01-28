using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductReviewManagement
{
    public class Management
    {
        public void TopRecords(List<ProductReview> review)
        {

            var recordedData = (from productReviews in review
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:-" + list.ProductID + " " + "UserID:-" + list.UserID
                    + " " + "Rating:-" + list.Rating + " " + "Review:-" + list.Review + " " + "isLike:-" + list.isLike);
            }
        }
        public void SelectedRecords(List<ProductReview> review)
        {
            var recordedData = from productReviews in review
                               where (productReviews.ProductID == 1 && productReviews.Rating > 3) || (productReviews.ProductID == 4 && productReviews.Rating > 3) ||
                               (productReviews.ProductID == 9 && productReviews.Rating > 3)
                               select productReviews;
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:-" + list.ProductID + " " + "UserID:-" + list.UserID
                    + " " + "Rating:-" + list.Rating + " " + "Review:-" + list.Review + " " + "isLike:-" + list.isLike);
            }
        }
        public void RetrieveCountOfRecords(List<ProductReview> review)
        {
            var recordedData = review.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "-----" + list.Count);
            }
        }
        public void RetrieveProductIdAndReview(List<ProductReview> review)
        {
            var recordedData = from productReviews in review
                               select new { productReviews.ProductID, productReviews.Review };
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:-" + list.ProductID + " " + "Review:-" + list.Review);
            }
        }
    }
}
