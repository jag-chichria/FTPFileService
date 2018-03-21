using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.rssb.win.services.ffc.enums
{
    public enum ActionToPerform
    {
        FileForNextIteration,
        FileFailedToDelete,
        FileDeleted
    }

    public enum FileDateProperty
    {
        DateCreated,
        DateAdded,
        DateModified
    }

    public enum DatabaseTypeEnum
    {
        SQLDatabase,
        CSVDatabase
    }
}
