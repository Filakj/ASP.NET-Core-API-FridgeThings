import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Instruction } from '../../Models/fridgethingsModels/instruction';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InstructionService {

  constructor(private httpClient: HttpClient) { }

  instructionUrl = 'http://fridgethingsapi.azurewebsites.net/api/Instructions/' 
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getInstructions(): Promise<Instruction[]> {
    console.log(this.instructionUrl);
    return this.httpClient.get<Instruction[]>(this.instructionUrl).toPromise();
  }

  getInstructionById(id: number): Promise<Instruction> {
    var completeUrl = `${this.instructionUrl}${id}`;
    console.log(completeUrl);
    return this.httpClient.get<Instruction>(completeUrl).toPromise();
  }

  postInstruction(newInstruction: Instruction): Observable<Instruction> {
    console.log(this.instructionUrl);
    console.log(newInstruction);
    return this.httpClient.post<Instruction>(this.instructionUrl, newInstruction, this.httpOptions);
  }

  putInstruction(newInstruction: Instruction): Observable<any> {
    var completeUrl = `${this.instructionUrl}${newInstruction.id}`;
    console.log(completeUrl);
    return this.httpClient.put(completeUrl, newInstruction, this.httpOptions);
  }

  deleteInstruction(id: number): Observable<Instruction> {
    var completeUrl = `${this.instructionUrl}${id}`;
    console.log(completeUrl);
    return this.httpClient.delete<Instruction>(completeUrl, this.httpOptions);
  }
}
