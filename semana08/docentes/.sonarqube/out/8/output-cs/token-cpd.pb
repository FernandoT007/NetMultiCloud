ﬂ
rD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Services\IUsuarioService.cs
	namespace 	
Docentes
 
. 
Application 
. 
Services '
;' (
public 
	interface 
IUsuarioService  
{ 
Task 
< 	
bool	 
> 
UsuarioExistAsync  
(  !
Guid! %
	usuarioId& /
,/ 0
CancellationToken1 B
cancellationTokenC T
)T U
;U V
} Ÿ
qD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Services\ICursosService.cs
	namespace 	
Docentes
 
. 
Application 
. 
Services '
;' (
public 
	interface 
ICursosService 
{ 
Task 
< 	
bool	 
> 
CursoExistAsync 
( 
Guid #
cursoId$ +
,+ ,
CancellationToken- >
cancellationToken? P
)P Q
;Q R
} ó
pD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Services\ICacheService.cs
	namespace 	
Docentes
 
. 
Application 
. 
Services '
;' (
public 
	interface 
ICacheService 
{ 
Task 
< 
T 	
?	 

>
 
GetCacheValueAsync 
< 
T  
>  !
(! "
string" (
key) ,
), -
;- .
Task 
SetCacheValueAsync 
< 
T 
> 
( 
string $
key% (
,( )
T* +
value, 1
,1 2
TimeSpan3 ;
?; <
expirationTime= K
=L M
nullN R
)R S
;S T
} Â
yD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Exceptions\ValidationExceptions.cs
	namespace 	
Docentes
 
. 
Application 
. 

Exceptions )
;) *
public 
class  
ValidationExceptions !
:" #
	Exception$ -
{ 
public 

IEnumerable 
< 
ValidationError &
>& '
Errors( .
{/ 0
get1 4
;4 5
}6 7
public 
 
ValidationExceptions 
(  
IEnumerable  +
<+ ,
ValidationError, ;
>; <
errors= C
)C D
{ 
Errors		 
=		 
errors		 
;		 
}

 
} ÿ
tD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Exceptions\ValidationError.cs
	namespace 	
Docentes
 
. 
Application 
. 

Exceptions )
;) *
public 
record 
ValidationError 
( 
string 

PropertyName 
, 
string 

ErrorMessage 
) 
; Ò
yD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Exceptions\ConcurrencyException.cs
	namespace 	
Docentes
 
. 
Application 
. 

Exceptions )
;) *
public 
sealed 
class  
ConcurrencyException (
:) *
	Exception+ 4
{ 
public 
 
ConcurrencyException 
(  
string  &
message' .
,. /
	Exception0 9
	exception: C
)C D
: 
base 	
(
 
message 
, 
	exception 
) 
{ 
}

 
} å
ÑD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Docentes\GetDocente\GetDocenteQueryHandler.cs
	namespace 	
Docentes
 
. 
Application 
. 
Docentes '
.' (

GetDocente( 2
;2 3
internal 
sealed	 
class "
GetDocenteQueryHandler ,
:- .
IQueryHandler/ <
<< =
GetDocenteQuery= L
,L M
DocenteResponseN ]
>] ^
{ 
private		 
readonly		 
IDocenteRepository		 '
_docenteRepository		( :
;		: ;
public 
"
GetDocenteQueryHandler !
(! "
IDocenteRepository" 4
docenteRepository5 F
)F G
{ 
_docenteRepository 
= 
docenteRepository .
;. /
} 
public 

async 
Task 
< 
Result 
< 
DocenteResponse ,
>, -
>- .
Handle/ 5
(5 6
GetDocenteQuery6 E
requestF M
,M N
CancellationTokenO `
cancellationTokena r
)r s
{ 
var 
docenteResult 
= 
await !
_docenteRepository" 4
.4 5
GetByIdAsync5 A
(A B
requestB I
.I J
	DocenteIdJ S
,S T
cancellationTokenU f
)f g
;g h
if 

( 
docenteResult 
== 
null !
)! "
{ 	
return 
Result 
. 
Failure !
<! "
DocenteResponse" 1
>1 2
(2 3
DocenteErrors3 @
.@ A
NotFoundA I
)I J
;J K
} 	
return 
Result 
. 
Success 
( 
new !
DocenteResponse" 1
(1 2
docenteResult 
. 
Id 
, 
docenteResult 
. 
	UsuarioId $
,$ %
docenteResult 
. 
EspecialidadId )
)	 

)
 
; 
} 
} ∏
}D:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Docentes\GetDocente\GetDocenteQuery.cs
	namespace 	
Docentes
 
. 
Application 
. 
Docentes '
.' (

GetDocente( 2
;2 3
public 
sealed 
record 
GetDocenteQuery $
($ %
Guid% )
	DocenteId* 3
)3 4
:5 6
IQuery7 =
<= >
DocenteResponse> M
>M N
;N Oƒ
}D:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Docentes\GetDocente\DocenteResponse.cs
	namespace 	
Docentes
 
. 
Application 
. 
Docentes '
.' (

GetDocente( 2
;2 3
public 
sealed 
record 
DocenteResponse $
( 
Guid 
Id	 
, 
Guid 
	UsuarioId	 
, 
Guid 
EspecialidadID	 
) 
; Ç
åD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Docentes\CrearDocente\CrearDocenteCommandValidator.cs
	namespace 	
Docentes
 
. 
Application 
. 
Docentes '
.' (
CrearDocente( 4
;4 5
public 
class (
CrearDocenteCommandValidator )
:* +
AbstractValidator, =
<= >
CrearDocenteCommand> Q
>Q R
{ 
public 
(
CrearDocenteCommandValidator '
(' (
)( )
{ 
RuleFor		 
(		 
c		 
=>		 
c		 
.		 
EspecialidadId		 %
)		% &
.

 
Must

 
(

 
guid

 
=>

 
Guid

 
.

 
TryParse

 '
(

' (
guid

( ,
.

, -
ToString

- 5
(

5 6
)

6 7
,

8 9
out

: =
_

> ?
)

? @
)

@ A
. 
WithMessage 
( 
$str N
)N O
;O P
;P Q
RuleFor 
( 
c 
=> 
c 
. 
	UsuarioId  
)  !
. 
Must 
( 
guid 
=> 
Guid 
. 
TryParse '
(' (
guid( ,
., -
ToString- 5
(5 6
)6 7
,8 9
out: =
_> ?
)? @
)@ A
. 
WithMessage 
( 
$str C
)C D
;D E
;E F
} 
} ›*
äD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Docentes\CrearDocente\CrearDocenteCommandHandler.cs
	namespace 	
Docentes
 
. 
Application 
. 
Docentes '
.' (
CrearDocente( 4
;4 5
internal 
sealed	 
class &
CrearDocenteCommandHandler 0
:1 2
ICommandHandler		 
<		 
CrearDocenteCommand		 #
,		# $
Guid		% )
>		) *
{

 
private 
readonly 
IDocenteRepository '
_docenteRepository( :
;: ;
private 
readonly 
IUnitOfWork  
_unitOfWork! ,
;, -
private 
readonly 
IUsuarioService $
_usuarioService% 4
;4 5
private 
readonly 
ICursosService #
_cursosService$ 2
;2 3
private 
readonly 
ICacheService "
_cacheService# 0
;0 1
public 
&
CrearDocenteCommandHandler %
(% &
IDocenteRepository& 8
docenteRepository9 J
,J K
IUnitOfWorkL W

unitOfWorkX b
,b c
IUsuarioServiced s
usuarioService	t Ç
,
Ç É
ICursosService
Ñ í
cursosService
ì †
,
† °
ICacheService
¢ Ø
cacheService
∞ º
)
º Ω
{ 
_docenteRepository 
= 
docenteRepository .
;. /
_unitOfWork 
= 

unitOfWork  
;  !
_usuarioService 
= 
usuarioService (
;( )
_cursosService 
= 
cursosService &
;& '
_cacheService 
= 
cacheService $
;$ %
} 
public 

async 
Task 
< 
Result 
< 
Guid !
>! "
>" #
Handle$ *
(* +
CrearDocenteCommand+ >
request? F
,F G
CancellationTokenH Y
cancellationTokenZ k
)k l
{ 
if 

( 
! 
await 
_usuarioService "
." #
UsuarioExistAsync# 4
(4 5
request5 <
.< =
	UsuarioId= F
,F G
cancellationTokenG X
)X Y
)Y Z
{ 	
return 
Result 
. 
Failure !
<! "
Guid" &
>& '
(' (
new( +
Error, 1
(1 2
$str2 C
,C D
$strD _
)_ `
)` a
;a b
} 	
var!! 
cacheKey!! 
=!! 
$"!! 
$str!! 
{!!  
request!!  '
.!!' (
EspecialidadId!!( 6
}!!6 7
"!!7 8
;!!8 9
var"" 

cursoExist"" 
="" 
await"" 
_cacheService"" ,
."", -
GetCacheValueAsync""- ?
<""? @
bool""@ D
>""D E
(""E F
cacheKey""F N
)""N O
;""O P
if$$ 

($$ 
!$$ 

cursoExist$$ 
)$$ 
{%% 	

cursoExist&& 
=&& 
await&& 
_cursosService&& -
.&&- .
CursoExistAsync&&. =
(&&= >
request&&> E
.&&E F
EspecialidadId&&F T
,&&T U
cancellationToken&&U f
)&&f g
;&&g h
var'' 
expirationTime'' 
=''  
TimeSpan''! )
.'') *
FromMinutes''* 5
(''5 6
$num''6 7
)''7 8
;''8 9
await(( 
_cacheService(( 
.((  
SetCacheValueAsync((  2
(((2 3
cacheKey((3 ;
,((; <

cursoExist((< F
,((F G
expirationTime((G U
)((U V
;((V W
})) 	
if++ 

(++ 
!++ 

cursoExist++ 
)++ 
{,, 	
return-- 
Result-- 
.-- 
Failure-- !
<--! "
Guid--" &
>--& '
(--' (
new--( +
Error--, 1
(--1 2
$str--2 A
,--A B
$str--B b
)--b c
)--c d
;--d e
}.. 	
var00 
docente00 
=00 
Docente00 
.00 
Create00 $
(00$ %
request11 
.11 
	UsuarioId11 
,11 
request22 
.22 
EspecialidadId22 "
)33 	
;33	 

_docenteRepository55 
.55 
Add55 
(55 
docente55 &
.55& '
Value55' ,
)55, -
;55- .
await66 
_unitOfWork66 
.66 
SaveChangesAsync66 *
(66* +
cancellationToken66+ <
)66< =
;66= >
return77 
docente77 
.77 
Value77 
.77 
Id77 
;77  
}88 
}99 ·
ÉD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Docentes\CrearDocente\CrearDocenteCommand.cs
	namespace 	
Docentes
 
. 
Application 
. 
Docentes '
.' (
CrearDocente( 4
;4 5
public 
record 
CrearDocenteCommand !
( 
Guid 
	UsuarioId 
, 
Guid 
EspecialidadId	 
)		 
:		 
ICommand		 
<		 
Guid		 
>		 
;		 Ê
mD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\DependencyInjection.cs
	namespace 	
Docentes
 
. 
Application 
; 
public 
static 
class 
DependencyInjection '
{ 
public		 	
static		
 
IServiceCollection		 #
AddApplication		$ 2
(		2 3
this		3 7
IServiceCollection		8 J
services		K S
)		S T
{

 
services 
. 

AddMediatR 
( 
configuration '
=>( *
{ 
configuration	 
. (
RegisterServicesFromAssembly 3
(3 4
typeof4 :
(: ;
DependencyInjection; N
)N O
.O P
AssemblyP X
)X Y
;Y Z
configuration	 
. 
AddOpenBehavior &
(& '
typeof' -
(- .
LoggingBehavior. =
<= >
,> ?
>? @
)@ A
)A B
;B C
configuration	 
. 
AddOpenBehavior &
(& '
typeof' -
(- .
ValidationBehavior. @
<@ A
,A B
>B C
)C D
)D E
;E F
} 
) 
; 	
services 
. %
AddValidatorsFromAssembly (
(( )
typeof) /
(/ 0
DependencyInjection0 C
)C D
.D E
AssemblyE M
)M N
;N O
return 
services 
; 
} 
} ò
~D:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Abstractions\Messaging\IQueryHandler.cs
	namespace 	
Docentes
 
. 
Application 
. 
Abstractions +
.+ ,
	Messaging, 5
;5 6
public 
	interface 
IQueryHandler 
< 
TQuery %
,% &
	TResponse' 0
>0 1
: 
IRequestHandler 
< 
TQuery 
, 
Result  
<  !
	TResponse! *
>* +
>+ ,
where 
TQuery 
: 
IQuery 
< 
	TResponse 
>  
{		 
} ¬
wD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Abstractions\Messaging\IQuery.cs
	namespace 	
Docentes
 
. 
Application 
. 
Abstractions +
.+ ,
	Messaging, 5
;5 6
public 
	interface 
IQuery 
< 
	TResponse !
>! "
:" #
IRequest$ ,
<, -
Result- 3
<3 4
	TResponse4 =
>= >
>> ?
{ 
}		 ä	
ÄD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Abstractions\Messaging\ICommandHandler.cs
	namespace 	
Docentes
 
. 
Application 
. 
Abstractions +
.+ ,
	Messaging, 5
;5 6
public 
	interface 
ICommandHandler  
<  !
TCommand! )
>) *
:+ ,
IRequestHandler- <
<< =
TCommand= E
,E F
ResultF L
>L M
where 
TCommand 
: 
ICommand 
{ 
}

 
public 
	interface 
ICommandHandler  
<  !
TCommand! )
,) *
	TResponse* 3
>3 4
:5 6
IRequestHandler7 F
<F G
TCommandG O
,O P
ResultP V
<V W
	TResponseW `
>` a
>a b
where 
TCommand 
: 
ICommand 
< 
	TResponse #
># $
{ 
} •
yD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Abstractions\Messaging\ICommand.cs
	namespace 	
Docentes
 
. 
Application 
. 
Abstractions +
.+ ,
	Messaging, 5
;5 6
public 
	interface 
ICommand 
: 
IRequest $
<$ %
Result% +
>+ ,
,- .
IBaseCommand/ ;
{ 
}		 
public 
	interface 
ICommand 
< 
	TResponse #
># $
:% &
IRequest' /
</ 0
Result0 6
<6 7
	TResponse7 @
>@ A
>A B
,C D
IBaseCommandE Q
{ 
} 
public 
	interface 
IBaseCommand 
{ 
} ¸
ÅD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Abstractions\Data\ISqlConnectionFactory.cs
	namespace 	
Docentes
 
. 
Application 
. 
Abstractions +
.+ ,
Data, 0
;0 1
public 
	interface !
ISqlConnectionFactory &
{ 
IDbConnection 
CreateConnection "
(" #
)# $
;$ %
} ‡
ÉD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Abstractions\Behaviors\ValidationBehavior.cs
	namespace 	
Docentes
 
. 
Application 
. 
Abstractions +
.+ ,
	Behaviors, 5
;5 6
public 
class 
ValidationBehavior 
<  
TRequest  (
,( )
	TResponse* 3
>3 4
:		 
IPipelineBehavior		 
<		 
TRequest		 
,		 
	TResponse		 '
>		' (
where

 
TRequest

 
:

 
IBaseCommand

 
{ 
private 
readonly 
IEnumerable  
<  !

IValidator! +
<+ ,
TRequest, 4
>4 5
>5 6
_validators7 B
;B C
public 

ValidationBehavior 
( 
IEnumerable )
<) *

IValidator* 4
<4 5
TRequest5 =
>= >
>> ?

validators@ J
)J K
{ 
_validators 
= 

validators  
;  !
} 
public 

async 
Task 
< 
	TResponse 
>  
Handle! '
(' (
TRequest 
request 
, "
RequestHandlerDelegate 
< 
	TResponse (
>( )
next* .
,. /
CancellationToken 
cancellationToken +
)+ ,
{ 
if 

(
 
! 
_validators 
. 
Any 
( 
) 
) 
{ 	
return 
await 
next 
( 
) 
;  
} 	
var 
context 
= 
new 
ValidationContext +
<+ ,
TRequest, 4
>4 5
(5 6
request6 =
)= >
;> ?
var 
validationErrores 
= 
_validators  +
.   	
Select  	 
(   

validators   
=>   

validators   )
.  ) *
Validate  * 2
(  2 3
context  3 :
)  : ;
)  ; <
.!! 	
Where!!	 
(!! 
validationsResult!! !
=>!!" $
validationsResult!!% 6
.!!6 7
Errors!!7 =
.!!= >
Any!!> A
(!!A B
)!!B C
)!!C D
."" 	

SelectMany""	 
("" 
validationResult"" %
=>""& (
validationResult"") 9
.""9 :
Errors"": @
)""@ A
.## 	
Select##	 
(## 
validatorsFailure$$	 
=>$$ 
new$$ !
ValidationError$$" 1
($$2 3
validatorsFailure%% 
.%% 
PropertyName%% *
,%%* +
validatorsFailure&& 
.&& 
ErrorMessage&& *
)'' 	
)''	 

.''
 
ToList'' 
('' 
)'' 
;'' 
if)) 

())
 
validationErrores)) 
.)) 
Any))  
())  !
)))! "
)))" #
{** 	
throw++ 
new++ 

Exceptions++  
.++  ! 
ValidationExceptions++! 5
(++5 6
validationErrores++6 G
)++G H
;++H I
},, 	
return-- 
await-- 
next-- 
(-- 
)-- 
;-- 
}// 
}00 á
ÄD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Application\Abstractions\Behaviors\LoggingBehavior.cs
	namespace 	
Docentes
 
. 
Application 
. 
Abstractions +
.+ ,
	Behaviors, 5
;5 6
public 
class 
LoggingBehavior 
< 
TRequest %
,% &
	TResponse' 0
>0 1
: 
IPipelineBehavior 
< 
TRequest 
, 
	TResponse '
>' (
where		 
TRequest		 
:		 
IBaseCommand		 
{

 
private 
readonly 
ILogger 
< 
TRequest %
>% &
_logger' .
;. /
public 

LoggingBehavior 
( 
ILogger "
<" #
TRequest# +
>+ ,
logger- 3
)3 4
{ 
_logger 
= 
logger 
; 
} 
public 

async 
Task 
< 
	TResponse 
>  
Handle! '
(' (
TRequest 
request 
, "
RequestHandlerDelegate 
< 
	TResponse (
>( )
next* .
,. /
CancellationToken 
cancellationToken +
)+ ,
{ 
var 
nameRequest 
= 
request !
.! "
GetType" )
() *
)* +
.+ ,
Name, 0
;0 1
try 
{ 	
_logger 
. 
LogInformation "
(" #
$"# %
$str% :
{: ;
nameRequest; F
}F G
"G H
)H I
;I J
var 
result 
= 
await 
next #
(# $
)$ %
;% &
_logger 
. 
LogInformation "
(" #
$"# %
$str% 7
{7 8
nameRequest8 C
}C D
"D E
)E F
;F G
return 
result 
; 
} 	
catch 
( 
	Exception 
ex 
) 
{   	
_logger!! 
.!! 
LogError!! 
(!! 
ex!! 
,!!  
$"!!! #
$str!!# /
{!!/ 0
nameRequest!!0 ;
}!!; <
$str!!< O
"!!O P
)!!P Q
;!!Q R
throw"" 
;"" 
}## 	
}$$ 
}%% 