﻿namespace trafficpolice.Models
{
    public enum responseStatus
    {
        ok, iderror, nameerror, phoneerror, tokenerror,
        requesterror, imageerror, fileprocesserror, access_tokenerror, ticketerror
      , postaddrerror, dberror, processerror, livingerror, compareerror
      , nouser, residencepictureerror, acceptingplaceerror, businesstypeerror, pictypeerror
      , vcodeerror, losttimeerror, forbidden, startdateerror, enddateerror
      , abroadorserviceerror, passerror,overdueerror,nounit,newpasserror
            ,allreadysubmitted
    };
}