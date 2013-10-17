﻿using System;
using SharpRepository.Repository.Aspects;

namespace SharpRepository.Tests.Integration.TestObjects
{
    public class CurrentDateTimeSetterAttribute : RepositoryActionBaseAttribute
    {
        public override bool OnAddExecuting<T, TKey>(T entity, RepositoryActionContext<T, TKey> context)
        {
            // this is hacky but just for testing
            var tmp = entity as AspectTestObject;

            if (tmp != null)
            {
                if (tmp.Created == DateTime.MinValue)
                {
                    tmp.Created = DateTime.UtcNow;
                }
            }

            return true;
        }
    }

    [CurrentDateTimeSetter]
    public class AspectTestObject
    {
        public int AspectTestObjectId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
    }
}
