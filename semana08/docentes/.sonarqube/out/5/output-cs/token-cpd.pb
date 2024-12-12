¹
YD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.api\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder

 
.

 
Services

 
.

 #
AddEndpointsApiExplorer

 (
(

( )
)

) *
;

* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
options  '
=>( *
{ 
options 
. 

SwaggerDoc 
( 
$str 
, 
new  #
OpenApiInfo$ /
{0 1
Version 
= 
$str 
, 
Title 
= 
$str "
," #
Description 
= 
$str ;
,; <
Contact 
= 
new 
OpenApiContact (
{) *
Name 
= 
$str '
,' (
Email 
= 
$str 3
} 
} 
) 	
;	 

} 
) 
; 
builder 
. 
Services 
. 
AddApplication 
(  
)  !
;! "
builder 
. 
Services 
. 
AddInfrastructure "
(" #
builder# *
.* +
Configuration+ 8
)8 9
;9 :
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app   
.   

UseSwagger   
(   
)   
;   
app!! 
.!! 
UseSwaggerUI!! 
(!! 
)!! 
;!! 
}"" 
app$$ 
.$$ 
ApplyMigrations$$ 
($$ 
)$$ 
;$$ 
app&& 
.&& %
UseCustomExceptionHandler&& 
(&& 
)&& 
;&&  
app(( 
.(( 
MapControllers(( 
((( 
)(( 
;(( 
app** 
.** 
Run** 
(** 
)** 	
;**	 
´%
xD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.api\Middleware\ExceptionHandlingMiddleware.cs
	namespace 	
Docentes
 
. 
Api 
. 

Middleware !
;! "
public 
class '
ExceptionHandlingMiddleware (
{ 
private 
readonly 
RequestDelegate $
_next% *
;* +
private		 
readonly		 
ILogger		 
<		 '
ExceptionHandlingMiddleware		 8
>		8 9
_logger		: A
;		A B
public 
'
ExceptionHandlingMiddleware &
(& '
RequestDelegate' 6
next7 ;
,; <
ILogger= D
<D E'
ExceptionHandlingMiddlewareE `
>` a
loggerb h
)h i
{ 
_next 
= 
next 
; 
_logger 
= 
logger 
; 
} 
public 

async 
Task 
InvokeAsync !
(! "
HttpContext" -
context. 5
)5 6
{ 
try 
{ 	
await 
_next 
( 
context 
)  
;  !
} 	
catch 
( 
	Exception 
ex 
) 
{ 	
_logger 
. 
LogError 
( 
ex 
,  
$str! C
,C D
exE G
.G H
MessageH O
)O P
;P Q
var 
excepcionDetail 
=  !
GetExceptionDeails" 4
(4 5
ex5 7
)7 8
;8 9
var 
problemDetail 
= 
new  #
ProblemDetails$ 2
{ 
Status 
= 
excepcionDetail (
.( )
Status) /
,/ 0
Type 
= 
excepcionDetail &
.& '
Type' +
,+ ,
Title 
= 
excepcionDetail '
.' (
Title( -
,- .
Detail   
=   
excepcionDetail   (
.  ( )
Detail  ) /
,  / 0
}!! 
;!! 
if## 
(## 
excepcionDetail## 
.##  
Errors##  &
is##( *
not##+ .
null##/ 3
)##3 4
{$$ 
problemDetail%% 
.%% 

Extensions%% (
[%%( )
$str%%) 1
]%%1 2
=%%3 4
excepcionDetail%%5 D
.%%D E
Errors%%E K
;%%K L
}&& 
context(( 
.(( 
Response(( 
.(( 

StatusCode(( '
=((( )
excepcionDetail((* 9
.((9 :
Status((: @
;((@ A
await** 
context** 
.** 
Response** "
.**" #
WriteAsJsonAsync**# 3
(**3 4
problemDetail**4 A
)**A B
;**B C
}++ 	
},, 
private.. 
static.. 
ExceptionDetails.. #
GetExceptionDeails..$ 6
(..6 7
	Exception..7 @
	exception..A J
)..J K
{// 
return00 
	exception00 
switch00 
{11 	 
ValidationExceptions22  
validationException22! 4
=>225 7
new228 ;
ExceptionDetails22< L
(22L M
StatusCodes33 
.33 
Status400BadRequest33 /
,33/ 0
$str44 #
,44# $
$str55 %
,55% &
$str66 >
,66> ?
validationException77 #
.77# $
Errors77$ *
)88 
,88 
_99 
=>99 
new99 
ExceptionDetails99 %
(99% &
StatusCodes:: 
.:: (
Status500InternalServerError:: :
,::: ;
$str;; 
,;; 
$str<< $
,<<$ %
$str== =
,=== >
null>> 
)?? 
}@@ 	
;@@	 

}AA 
internalCC 
recordCC 
ExceptionDetailsCC $
(DD 
intEE 
StatusEE 
,EE 
stringFF 
TypeFF 
,FF 
stringGG 
TitleGG 
,GG 
stringHH 
DetailHH 
,HH 
IEnumerableII 
<II 
objectII 
>II 
?II 
ErrorsII #
)JJ 
;JJ 
}LL ‚
yD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.api\Extensions\ApplicationBuilderExtensions.cs
	namespace 	
Docentes
 
. 
Api 
. 

Extensions !
;! "
public 
static 
class (
ApplicationBuilderExtensions 0
{ 
public		 

static		 
async		 
void		 
ApplyMigrations		 ,
(		, -
this		- 1
IApplicationBuilder		2 E
app		F I
)		I J
{

 
using 
( 
var 
scope 
= 
app 
. 
ApplicationServices 1
.1 2
CreateScope2 =
(= >
)> ?
)? @
{ 	
var 
service 
= 
scope 
.  
ServiceProvider  /
;/ 0
var 
loggerFactory 
= 
service  '
.' (
GetRequiredService( :
<: ;
ILoggerFactory; I
>I J
(J K
)K L
;L M
try 
{ 
var 
context 
= 
service %
.% &
GetRequiredService& 8
<8 9 
ApplicationDbContext9 M
>M N
(N O
)O P
;P Q
await 
context 
. 
Database &
.& '
MigrateAsync' 3
(3 4
)4 5
;5 6
} 
catch 
( 
	Exception 
ex 
)  
{ 
var 
logger 
= 
loggerFactory *
.* +
CreateLogger+ 7
<7 8
Program8 ?
>? @
(@ A
)A B
;B C
logger 
. 
LogError 
(  
ex  "
," #
$str# :
): ;
;; <
} 
} 	
} 
public 

static 
void %
UseCustomExceptionHandler 0
(0 1
this1 5
IApplicationBuilder6 I
appJ M
)M N
{ 
app 
. 
UseMiddleware 
< '
ExceptionHandlingMiddleware 5
>5 6
(6 7
)7 8
;8 9
}   
}!! Ô
xD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.api\Controllers\Docentes\DocenteController.cs
	namespace 	
Docentes
 
. 
api 
. 
Controllers "
." #
Docentes# +
;+ ,
[ 
ApiController 
] 
[		 
Route		 
(		 
$str		 
)		 
]		 
public

 
class

 
DocenteController

 
:

  !
ControllerBase

" 0
{ 
private 
readonly 
ISender 
_sender &
;& '
public 

DocenteController 
( 
ISender $
sender% +
)+ ,
{ 
_sender 
= 
sender 
; 
} 
[ 
HttpGet 
( 
$str 
) 
] 
public 

async 
Task 
< 
IActionResult #
># $
ObtenerDocente% 3
(3 4
Guid 
id 
, 
CancellationToken 
cancellationToken +
) 
{ 
var 
query 
= 
new 
GetDocenteQuery '
(' (
id( *
)* +
;+ ,
var 
	resultado 
= 
await 
_sender %
.% &
Send& *
(* +
query+ 0
,0 1
cancellationToken1 B
)B C
;C D
return 
	resultado 
. 
	IsSuccess "
?# $
Ok% '
(' (
	resultado( 1
)1 2
:3 4
NotFound5 =
(= >
)> ?
;? @
} 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
CrearDocente% 1
(1 2
CrearDocenteRequest  	 
request   $
,  $ %
CancellationToken!! 
cancellationToken!! +
)"" 
{## 
var$$ 
command$$ 
=$$ 
new$$ 
CrearDocenteCommand$$ -
(%% 	
request&& 
.&& 
	UsuarioId&& 
,&& 
request'' 
.'' 
EspecialidadId'' "
)(( 	
;((	 

var** 
	resultado** 
=** 
await** 
_sender** %
.**% &
Send**& *
(*** +
command**+ 2
,**2 3
cancellationToken**3 D
)**D E
;**E F
if,, 

(,, 
	resultado,, 
.,, 
	IsSuccess,, 
),,  
{-- 	
return.. 
CreatedAtAction.. "
(.." #
nameof..# )
(..) *
ObtenerDocente..* 8
)..8 9
,..9 :
new..; >
{..? @
id..A C
=..D E
	resultado..F O
...O P
Value..P U
}..V W
,..X Y
	resultado..Z c
...c d
Value..d i
)..j k
;..k l
}// 	
return00 

BadRequest00 
(00 
	resultado00 #
.00# $
Error00$ )
)00) *
;00* +
}11 
}33 ù
zD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.api\Controllers\Docentes\CrearDocenteRequest.cs
	namespace 	
Docentes
 
. 
api 
. 
Controllers "
." #
Docentes# +
;+ ,
public 
record 
CrearDocenteRequest !
( 
Guid 
	UsuarioId	 
, 
Guid 
EspecialidadId	 
) 
; ¯
‰D:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.api\Controllers\CursosImpartidos\CursosImpartidosController.cs
	namespace 	
Docentes
 
. 
api 
. 
Controllers "
." #
CursosImpartidos# 3
;3 4
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
class &
CursosImpartidosController '
:) *
ControllerBase+ 9
{		 
private

 
readonly

 
ISender

 
_sender

 $
;

$ %
public 
&
CursosImpartidosController %
(% &
ISender& -
sender. 4
)4 5
{ 
_sender 
= 
sender 
; 
} 
} 