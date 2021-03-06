﻿using System;
using System.Collections.Generic;
using System.Linq;
using CrawlBot.Logic.Models;

namespace CrawlBot.Logic.Abstract
{
    public class ChangedContextItemRepository
    {
        public static List<LastChangedContextItem> ContextItems { get; } = new List<LastChangedContextItem>();

        public void Add(HttpResponse response)
        {
            var item = new LastChangedContextItem();
            item.Save(response);
            ContextItems.Add(item);
        }

        public void Add(LastChangedContextItem item)
        {
            ContextItems.Add(item);
        }

        public LastChangedContextItem GetLastChangedContextItem()
        {
            var item = ContextItems.OrderByDescending(i => i.ModificationDate, new DateTimeComparator()).ToList()[0];
            ContextItems.Remove(item);
            return item;
        }

        public LastChangedContextItem GetItemById(Guid id)
        {
            var item = ContextItems.Where(i => i.Id == id).ToList()[0];
            ContextItems.Remove(item);
            return item;
        }

        public class DateTimeComparator : IComparer<DateTime>
        {
            public int Compare(DateTime x, DateTime y)
            {
                return x.CompareTo(y);
            }
        }
    }
}
