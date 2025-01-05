


create or alter PROCEDURE pGetAppointment
@pAppointmentId uniqueidentifier
as
begin
	
	select
	a.Id,
	d.id as DoctorId,
	d.name as DoctorName,
	p.Id as PatientId,
	p.name as PatientName,
	a.AppointmentDate,
	500 as PriceAmount,
	(500 * 1.16) as TotalPriceAmount,
	a.status,
	a.AppointmentDate as CreatedOnUtc
	from Appointments a with(nolock)
	inner join Doctors d with(nolock)
		on a.doctorid = d.id
	inner join Patients p with(nolock)
		on a.PatientId = p.Id
	where a.Id = @pAppointmentId
	
end
GO


