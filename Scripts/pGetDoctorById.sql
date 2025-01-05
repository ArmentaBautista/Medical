create   proc pGetDoctorsById
@pDoctorId uniqueidentifier
as
begin
	select 
		Id,
		Name,
		LicenseNumber,
		Specialty
	from dbo.Doctors d with(nolock)
	where d.id = @pDoctorId
end
