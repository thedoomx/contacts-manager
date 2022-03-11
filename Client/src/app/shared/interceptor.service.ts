import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService {

  constructor() { }

  intercept(request: HttpRequest<any>, next: HttpHandler, ) {
    request = request.clone({
      setHeaders: {
        'Content-Type' : 'application/json',
      }
    });

    return next.handle(request);
  }
}
