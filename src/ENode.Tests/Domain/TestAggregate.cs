﻿using ENode.Domain;
using ENode.Eventing;

namespace ENode.Tests.Domain
{
    public class TestAggregate : AggregateRoot<string>
    {
        private string _title;

        public string Title { get { return _title; } }

        public TestAggregate(string id, string title) : base(id)
        {
            ApplyEvent(new TestAggregateCreated(title));
        }

        public void ChangeTitle(string title)
        {
            ApplyEvent(new TestAggregateTitleChanged(title));
        }

        public void TestEvents()
        {
            ApplyEvents(new Event1(), new Event2(), new Event3());
        }

        private void Handle(TestAggregateCreated evnt)
        {
            _title = evnt.Title;
        }
        private void Handle(Event1 evnt)
        {
        }
        private void Handle(Event2 evnt)
        {
        }
        private void Handle(Event3 evnt)
        {
        }
    }
    public class TestAggregateCreated : DomainEvent<string>
    {
        public string Title { get; private set; }

        public TestAggregateCreated() { }
        public TestAggregateCreated(string title)
        {
            Title = title;
        }
    }
    public class TestAggregateTitleChanged : DomainEvent<string>
    {
        public string Title { get; private set; }

        public TestAggregateTitleChanged() { }
        public TestAggregateTitleChanged(string title)
        {
            Title = title;
        }
    }
    public class Event1 : DomainEvent<string> { }
    public class Event2 : DomainEvent<string> { }
    public class Event3 : DomainEvent<string> { }
}