//================================
//Copyright (C) Coalitionof Good-Hearted Engineers
//Free To Use Comfort and Peace
//================================

using Xeptions;

namespace Sheenam.Api.Models.Foundations.Exeptions
{
    public class GuestValidationException: Xeption
    {
        public GuestValidationException(Xeption innerException)
       : base(message: "Guest validation error occurred, fix the errors and try again",
              innerException) 
        { }
    }
}
