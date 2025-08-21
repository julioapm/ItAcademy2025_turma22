import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from '../models/post';

@Injectable({
    providedIn: 'root'
})
export class PostsService {
    private urlBase = 'https://jsonplaceholder.typicode.com/posts';
    private httpClient = inject(HttpClient);

    buscarTodosPosts() {
        return this.httpClient.get<Post[]>(this.urlBase);
    }
}
