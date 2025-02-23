import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ILien } from './ILien';
import { LiensService } from './liens.service';
import { CommonModule } from '@angular/common';
import { map } from 'rxjs';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  // Liste des liens.
  liens: {
    id: number,
    titre: string,
    url: SafeUrl
  }[] = [];

  // Formulaire d'ajout.
  formAjout: FormGroup = new FormGroup({
    titre: new FormControl(''),
    url: new FormControl('')
  });

  /**
   * Constructeur.
   * @param serviceLiens Injection du service pour les liens.
   */
  constructor (private serviceLiens: LiensService, private domSanitizer: DomSanitizer) { }
  
  /**
   * Sur initialisation.
   */
  ngOnInit(): void {
    this.populerListe();
  }

  ajouter() {
    if (this.formAjout.valid) {
      const titre = this.formAjout.get('titre')?.value;
      const url = this.formAjout.get('url')?.value;
      this.serviceLiens.ajouter(titre, url).subscribe({
        next: _ => {
          this.formAjout.reset({
            titre: '',
            url: ''
          });
          this.populerListe();
        }
      });
    }
  }

  /**
   * Supprimer le lien.
   * @param id Identifiant.
   */
  supprimer(id: number) {
    this.serviceLiens.supprimer(id).subscribe({
      next: _ => {
        this.liens = this.liens.filter(p => p.id !== id).slice();
      }
    });
  }

  populerListe() {
    this.serviceLiens.obtenir().pipe(
      map(liste => {
        return liste.map(element => {
          return {
            id: element.id,
            titre: element.titre,
            url: this.domSanitizer.bypassSecurityTrustUrl(element.url)
          };
        });
      })
    ).subscribe({
      next: liste => {
        this.liens = liste;
      }
    });
  }
}
