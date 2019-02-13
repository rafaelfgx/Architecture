import { HttpClient, HttpEventType, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";

@Injectable({ providedIn: "root" })
export class AppFileService {
    constructor(private readonly http: HttpClient) { }

    upload(files: FileList): Observable<number> {
        if (files.length === 0) {
            return of(0);
        }

        const formData = new FormData();

        for (const file of files as any) {
            formData.append(file.name, file);
        }

        const request = new HttpRequest("POST", "Files", formData, { reportProgress: true, });

        return new Observable((observable) => {
            this.http.request(request).subscribe((event) => {
                if (event.type === HttpEventType.Response) {
                    return observable.next(100);
                }

                if (event.type === HttpEventType.UploadProgress) {
                    return observable.next(Math.round(100 * event.loaded / event.total));
                }
            });
        });
    }
}
