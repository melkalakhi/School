//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace School.POCO
{
    public partial class Trainee
    {
        #region Primitive Properties
    
        public virtual int ID
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual string FirstName
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Course> Course
        {
            get
            {
                if (_course == null)
                {
                    var newCollection = new FixupCollection<Course>();
                    newCollection.CollectionChanged += FixupCourse;
                    _course = newCollection;
                }
                return _course;
            }
            set
            {
                if (!ReferenceEquals(_course, value))
                {
                    var previousValue = _course as FixupCollection<Course>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupCourse;
                    }
                    _course = value;
                    var newValue = value as FixupCollection<Course>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupCourse;
                    }
                }
            }
        }
        private ICollection<Course> _course;

        #endregion
        #region Association Fixup
    
        private void FixupCourse(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Course item in e.NewItems)
                {
                    if (!item.Trainee.Contains(this))
                    {
                        item.Trainee.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Course item in e.OldItems)
                {
                    if (item.Trainee.Contains(this))
                    {
                        item.Trainee.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}
