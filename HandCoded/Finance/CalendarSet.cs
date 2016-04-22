// Copyright (C),2005-2012 HandCoded Software Ltd.
// All rights reserved.
//
// This software is licensed in accordance with the terms of the 'Open Source
// License (OSL) Version 3.0'. Please see 'license.txt' for the details.
//
// HANDCODED SOFTWARE LTD MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE
// SUITABILITY OF THE SOFTWARE, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
// PARTICULAR PURPOSE, OR NON-INFRINGEMENT. HANDCODED SOFTWARE LTD SHALL NOT BE
// LIABLE FOR ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING
// OR DISTRIBUTING THIS SOFTWARE OR ITS DERIVATIVES.

using System;
using System.Collections.Generic;
using System.Text;

namespace HandCoded.Finance
{
    /// <summary>
    /// An instance of the <b>CalendarSet</b> class holds a collection of
    /// <see cref="Calendar"/> instances used to define business days for date
    /// rolls.
    /// </summary>
    /// <remark>A date is only considered a business day if it is business day
    /// in all the underlying <see cref="Calendar"/> instances.</remark>
    public sealed class CalendarSet : Calendar
    {
        /// <summary>
        /// Constructs an empty <b>CalendarSet</b> instance.
        /// </summary>
	    public CalendarSet ()
            : base (null)
        { }

        /// <summary>
        /// Adds the indicated <see cref="Calendar"/> to the underlying collection.
        /// </summary>
        /// <param name="calendar">The <see cref="Calendar"/> to be added.</param>
	    public void Add (Calendar calendar)
	    {
		    calendars.Add (calendar);
	    }

        /// <summary>
        /// Determines if the <see cref="Date"/> provided falls on a business
        /// day in this <b>Calendar</b> (e.g. not a holiday or weekend).
        /// </summary>
        /// <param name="date">The <see cref="Date"/> to be tested.</param>
        /// <returns><c>true</c> if the date is a business day, <c>false</c>
        /// otherwise.</returns>
        public override bool IsBusinessDay (Date date)
	    {
		    foreach (Calendar calendar in calendars)
			    if (!calendar.IsBusinessDay (date))
				    return (false);
    		
		    return (true);
        }

	    ///
        /// The underlying set of <see cref="Calendar"/> instances.
	    ///
	    private List<Calendar>	calendars = new List<Calendar> ();
    }
}