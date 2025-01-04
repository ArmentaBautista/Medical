﻿using Medical.Domain.Abstractions;

namespace Medical.Domain.Appointments.Events
{
    public sealed record AppointmentCompletedDomainEvent(Guid AppointmentId) : IDomainEvent;
}