create PROCEDURE ZD_Suscripcion
@IdSuscriptor int
AS
BEGIN
	Delete from Suscripcion  where IdSuscriptor=@IdSuscriptor
END 
go

create PROCEDURE ZC_Suscripcion
@IdAsociacion int,
@IdSuscriptor int
AS
BEGIN
	SELECT IdAsociacion,IdSuscriptor,FechaAlta,FechaFin,MotivoFin
			from Suscripcion
      Where 
	  (@IdAsociacion=0 or IdAsociacion=@IdAsociacion)
	 and (@IdSuscriptor=0 or IdSuscriptor=@IdSuscriptor)
END
GO

create PROCEDURE ZIU_Suscripcion
 (
    @IdAsociacion int output,
	@IdSuscriptor integer,
	@FechaAlta datetime,
	@FechaFin  datetime,
	@MotivoFin varchar(500)
)
AS
BEGIN
	
    if not exists(
		select * from Suscripcion where  IdSuscriptor=@IdSuscriptor 
	)
    BEGIN		
		INSERT INTO Suscripcion(IdSuscriptor,FechaAlta,FechaFin,MotivoFin)
			 VALUES (@IdSuscriptor,@FechaAlta,@FechaFin,@MotivoFin)	
	    SET @IdSuscriptor =IDENT_CURRENT ('Suscripcion') 
    END
    ELSE
		BEGIN	
			UPDATE Suscripcion
			SET 
			IdSuscriptor =  @IdSuscriptor,
			FechaAlta =  @FechaAlta,
			FechaFin =  @FechaFin,
			MotivoFin =  @MotivoFin
			WHERE  IdSuscriptor=@IdSuscriptor 
		END 
	RETURN @IdSuscriptor
END 
GO

/**/
create PROCEDURE ZD_Suscriptor
@IdSuscriptor int
AS
BEGIN
	Delete from Suscriptor  where IdSuscriptor=@IdSuscriptor
END 
go

create PROCEDURE ZC_Suscriptor
@IdSuscriptor int,
@NumeroDocumento int,
@TipoDocumento varchar(100)
AS
BEGIN
	SELECT IdSuscriptor,Nombre,Apellido,NumeroDocumento,Direccion,TipoDocumento,Telefono,Email,NombreUsuario,
	Cast(DECRYPTBYPASSPHRASE('password',Password) as varchar(20)) as Password,
		(select count(*) from Suscripcion x
	where CONVERT(date,x.FechaFin,104)>=CONVERT(date,getdate(),104) 
	and x.IdSuscriptor=IdSuscriptor) as Valido
	from Suscriptor
	Where 
	 (@IdSuscriptor=0 or IdSuscriptor=@IdSuscriptor)
	 and (@NumeroDocumento=0 or NumeroDocumento=@NumeroDocumento)
	 and (@TipoDocumento='X' or TipoDocumento=@TipoDocumento)
END
GO

create PROCEDURE ZIU_Suscriptor
 (
    @Idsuscriptor int output,
	@Nombre varchar(50),
	@Apellido varchar(60),
	@Numerodocumento int,
	@Direccion varchar(500),
	@Tipodocumento varchar(100),
	@Telefono varchar(20),
	@Email varchar(50),
	@Nombreusuario varchar(20),
	@Password varchar(30)
)
AS
BEGIN
	
    if not exists(
		select * from Suscriptor where  IdSuscriptor=@IdSuscriptor 
	)
    BEGIN		
		INSERT INTO Suscriptor(Nombre,Apellido,NumeroDocumento,Direccion,TipoDocumento,Telefono,Email,NombreUsuario,Password)
			 VALUES (@Nombre,@Apellido,@NumeroDocumento,@Direccion,@TipoDocumento,@Telefono,@Email,@NombreUsuario,ENCRYPTBYPASSPHRASE('password', @Password))	
	    SET @IdSuscriptor =IDENT_CURRENT ('Suscriptor') 
    END
    ELSE
		BEGIN	
			UPDATE Suscriptor
			SET 
				Nombre =  @Nombre,
				Apellido =  @Apellido,
				Numerodocumento =  @Numerodocumento,
				Direccion =  @Direccion,
				Tipodocumento =  @Tipodocumento,
				Telefono =  @Telefono,
				Email =  @Email,
				Nombreusuario =  @Nombreusuario,
				Password =  ENCRYPTBYPASSPHRASE('password', @Password) 
			WHERE  IdSuscriptor=@IdSuscriptor 
		END 
	RETURN @IdSuscriptor
END 
GO

