create   proc pSearchDoctorsBySpecialty
@pSpecialty varchar(32)
as
begin
	select 
		Id,
		Name,
		LicenseNumber,
		Specialty
	from dbo.Doctors d with(nolock)
	where d.Specialty like '%' + @pSpecialty + '%'	
end
