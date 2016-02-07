﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture10Demos
{
    class ContactRepository
    {
        public event EventHandler<ContactEventArgs> ContactAdded;

        public void Add(Contact contact)
        {
            // TODO: Add contact to database.

            OnContactAdded(contact);
        }

        public void Remove(Contact contact)
        {
            // TODO: Remove from database.
        }

        private void OnContactAdded(Contact contact)
        {
            var eventHandlers = ContactAdded;
            if(eventHandlers != null)
            {
                eventHandlers(this, new ContactEventArgs { ContactName = contact.Name });
            }
        }
    }
}
