»
pD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Domain\Docentes\IDocenteRepository.cs
	namespace 	
Docentes
 
. 
Domain 
. 
Docentes "
;" #
public 
	interface 
IDocenteRepository #
{ 
Task 
< 	
Docente	 
? 
> 
GetByIdAsync 
(  
Guid  $
id% '
,' (
CancellationToken) :
cancellationToken; L
=M N
defaultO V
)V W
;W X
void 
Add	 
( 
Docente 
docente 
) 
; 
Task 
< 	
Docente	 
? 
> 
GetByIdUsuarioAsync &
(& '
Guid' +
	idUsuario, 5
,5 6
CancellationToken7 H
cancellationTokenI Z
=[ \
default] d
)d e
;e f
}

 ®
kD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Domain\Docentes\DocenteErrors.cs
	namespace 	
Docentes
 
. 
Domain 
. 
Docentes "
;" #
public 
static 
class 
DocenteErrors !
{ 
public 
static 
Error 
NotFound "
=# $
new% (
(( )
$str 
, 
$str		 *
)

 
;

 
} ·
eD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Domain\Docentes\Docente.cs
	namespace 	
Docentes
 
. 
Domain 
. 
Docentes "
;" #
public 
sealed 
class 
Docente 
: 
Entity $
{ 
private 
Docente 
( 
) 
{ 
} 
private		 
Docente		 
(		 
Guid

 
id

	 
,

 
Guid 
	usuarioId	 
, 
Guid 
especialidadId	 
) 
: 
base 
( 
id 
) 
{ 
	UsuarioId 
= 
	usuarioId 
; 
EspecialidadId 
= 
especialidadId '
;' (
} 
public 

Guid 
	UsuarioId 
{ 
get 
;  
private! (
set) ,
;, -
}. /
public 

Guid 
EspecialidadId 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public 
static 
Result 
< 
Docente !
>! "
Create# )
() *
Guid 
	usuarioId 
, 
Guid 
especialidadId 
) 
{ 
var 
docente 
= 
new 
Docente !
(! "
Guid 
. 
NewGuid 
( 
) 
, 
	usuarioId
 
, 
especialidadId
 
) 	
;	 

return   
docente   
;   
}!! 
}"" «
D:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Domain\CursosImpartidos\ICursoImpartidoRepository.cs
	namespace 	
Docentes
 
. 
Domain 
. 
CursosImpartidos *
;* +
public 
	interface %
ICursoImpartidoRepository *
{ 
Task 
< 	
CursoImpartido	 
? 
> 
GetByIdAsync &
(& '
Guid' +
id, .
,. /
CancellationToken0 A
cancellationTokenB S
=T U
defaultV ]
)] ^
;^ _
void 
Add	 
( 
CursoImpartido 
usuario #
)# $
;$ %
} ·
tD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Domain\CursosImpartidos\CursoImpartido.cs
	namespace 	
Docentes
 
. 
Domain 
. 
CursosImpartidos *
;* +
public 
sealed 
class 
CursoImpartido "
:# $
Entity% +
{ 
private 
CursoImpartido 
( 
) 
{ 
}  
public		 

CursoImpartido		 
(		 
Guid

 
id

 
,

 
Guid 
? 
	docenteId 
, 
Guid 
? 
cursoId 
) 
: 
base 
( 
id  
)  !
{ 
Id 

= 
id 
; 
	DocenteId 
= 
	docenteId 
; 
CursoId 
= 
cursoId 
; 
} 
public 

Guid 
? 
	DocenteId 
{ 
get  
;  !
set" %
;% &
}' (
public 

Guid 
? 
CursoId 
{ 
get 
; 
set  #
;# $
}% &
public 

Docente 
? 
Docente 
{ 
get !
;! "
set# &
;& '
}( )
} Ç(
hD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Domain\Abstractions\Result.cs
	namespace 	
Docentes
 
. 
Domain 
. 
Abstractions &
;& '
public 
class 
Result 
{ 
	protected 
internal 
Result 
( 
bool "
	isSuccess# ,
,, -
Error. 3
error4 9
)9 :
{ 
if		 

(		 
	isSuccess		 
&&		 
error		 
!=		 !
Error		" '
.		' (
None		( ,
)		, -
{

 	
throw 
new %
InvalidOperationException /
(/ 0
)0 1
;1 2
} 	
if 

( 
! 
	isSuccess 
&& 
error  
==! #
Error$ )
.) *
None* .
). /
{ 	
throw 
new %
InvalidOperationException /
(/ 0
)0 1
;1 2
} 	
	IsSuccess 
= 
	isSuccess 
; 
Error 
= 
error 
; 
} 
public 

bool 
	IsSuccess 
{ 
get 
;  
}! "
public 

bool 
	IsFailure 
=> 
! 
	IsSuccess '
;' (
public 

Error 
Error 
{ 
get 
; 
} 
public 

static 
Result 
Success  
(  !
)! "
=># %
new& )
() *
true* .
,. /
Error0 5
.5 6
None6 :
): ;
;; <
public 

static 
Result 
Failure  
(  !
Error! &
error' ,
), -
=>. 0
new1 4
(4 5
false5 :
,: ;
error< A
)A B
;B C
public 

static 
Result 
< 
TValue 
>  
Success! (
<( )
TValue) /
>/ 0
(0 1
TValue1 7
value8 =
)= >
=>   
new   
(   
value   
,   
true   
,   
Error   
.   
None   #
)  # $
;  $ %
public"" 

static"" 
Result"" 
<"" 
TValue"" 
>""  
Failure""! (
<""( )
TValue"") /
>""/ 0
(""0 1
Error""1 6
error""7 <
)""< =
=>## 
new## 
(## 
default## 
,## 
false## 
,## 
error## 
)##  
;##  !
public%% 

static%% 
Result%% 
<%% 
TValue%% 
>%%  
Create%%! '
<%%' (
TValue%%( .
>%%. /
(%%/ 0
TValue%%0 6
?%%6 7
value%%8 =
)%%= >
=>&& 
value&& 
is&& 
not&& 
null&& 
?'' 
Success'' 
('' 
value'' 
)'' 
:(( 
Failure(( 
<(( 
TValue(( 
>(( 
((( 
Error(( 
.(( 
	NullValue(( '
)((' (
;((( )
}** 
public,, 
class,, 
Result,, 
<,, 
Tvalue,, 
>,, 
:,, 
Result,, $
{-- 
private.. 
readonly.. 
Tvalue.. 
?.. 
_value.. #
;..# $
	protected00 
internal00 
Result00 
(00 
Tvalue00 $
?00$ %
value00& +
,00+ ,
bool00- 1
	isSuccess002 ;
,00; <
Error00= B
error00C H
)00H I
:11 
base11 

(11
 
	isSuccess11 
,11 
error11 
)11 
{22 
_value33 
=33 
value33 
;33 
}44 
[66 
NotNull66 
]66 
public77 

Tvalue77 
Value77 
=>77 
	IsSuccess77 $
?88 
_value88 
!88 
:99 
throw99 
new99 %
InvalidOperationException99 *
(99* +
$str99+ \
)99\ ]
;99] ^
public;; 

static;; 
implicit;; 
operator;; #
Result;;$ *
<;;* +
Tvalue;;+ 1
>;;1 2
(;;2 3
Tvalue;;3 9
value;;: ?
);;? @
=>;;A C
Create;;D J
(;;J K
value;;K P
);;P Q
;;;Q R
}== ¿
mD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Domain\Abstractions\IUnitOfWork.cs
	namespace 	
Docentes
 
. 
Domain 
. 
Abstractions &
;& '
public 
	interface 
IUnitOfWork 
{ 
Task 
< 	
int	 
> 
SaveChangesAsync 
( 
CancellationToken 0
cancellationToken1 B
=C D
defaultE L
)L M
;M N
} ¢
gD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Domain\Abstractions\Error.cs
	namespace 	
Docentes
 
. 
Domain 
. 
Abstractions &
;& '
public 
record 
Error 
( 
string 
Code  
,  !
string" (
Name) -
)- .
{ 
public 

static 
Error 
None 
= 
new "
(" #
string$ *
.* +
Empty+ 0
,0 1
string2 8
.8 9
Empty9 >
)? @
;@ A
public 

static 
Error 
	NullValue !
=" #
new$ '
(' (
$str( 9
,9 :
$str: W
)W X
;X Y
} œ
hD:\Git\NetMultiCloud\NetMultiCloud\semana08\docentes\src\Docentes\Docentes.Domain\Abstractions\Entity.cs
	namespace 	
Docentes
 
. 
Domain 
. 
Abstractions &
;& '
public 
abstract 
class 
Entity 
{ 
	protected 
Entity 
( 
) 
{ 
} 
	protected 
Entity 
( 
Guid 
id 
) 
{ 
Id 

= 
id 
; 
}		 
public

 

Guid

 
Id

 
{

 
get

 
;

 
init

 
;

 
}

  !
} 