MediatR
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Abstractions
Microsoft.EntityFrameworkCore.Analyzers
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.InMemory
Microsoft.EntityFrameworkCore.Relational
Microsoft.EntityFrameworkCore.Tools

-----------------------------------------------------------

IRequest<out TResponse>
IRequestHandler<in IRequest, TResponse>
INotificationHandler<in TNotification>


-----------------------------------------------------------------


مفهوم  IRequest<TResponse> و IRequestHandler<TRequest, TResponse> در MediatR در C# می‌تواند کمی گیج‌کننده باشد، به‌ویژه وقتی با کلیدواژه‌های in و out روبه‌رو می‌شوید. اجازه دهید این موارد را بیشتر توضیح دهم.
IRequest<TResponse>
•	این رابط نمایانگر یک درخواست است که می‌تواند به یک Handlers ارسال شود و انتظار یک پاسخ با نوع مشخص شده (TResponse) را دارد.
•	وقتی شما از IRequest<TResponse> استفاده می‌کنید، در واقع می‌گویید که این درخواست یک پاسخ از نوع TResponse را به همراه خواهد داشت.
IRequestHandler<TRequest, TResponse>
•	این رابط، نمایش‌دهنده یک Handler برای پردازش درخواست‌ها است. در اینجا:
o	TRequest نوع درخواست (که می‌تواند یک کلاس باشد که از IRequest<TResponse> پیروی می‌کند).
o	TResponse نوع پاسخ است که Handler باید بازگرداند.
•	با توجه به آداپتورهای in و out:
o	استفاده از in در IRequestHandler<in TRequest, TResponse> نشان‌دهنده این است که Handler می‌تواند هر نوع TRequest را که یک کلاس والد یا عمومی‌تر باشد مدیریت کند. این امر نشان می‌دهد که می‌توان از مواد سلسله‌مراتبی برای انواع درخواست‌ها استفاده کرد.
درک in  و out در MediatR
•	in TRequest:  یعنی TRequest مورد انتظار است که می‌تواند هر زیرکلاسی از نوع خاص‌تر باشد. این به شما این امکان را می‌دهد که Handler بتواند انواع متنوعی از درخواست‌ها را پردازش کند.
•	out TResponse:  در اینجا، TResponse به طور خاص بازمی‌گردد و باید فقط به عنوان خروجی استفاده شود.

----------------------------------------------------------------------------------------------------

sample 
             await mediatr.Send(createProductCommand);
            await mediatr.Publish(new ProductCreatedNotification(guid));
