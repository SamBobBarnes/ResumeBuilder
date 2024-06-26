import { Component, Input, Optional, Self } from '@angular/core';
import { ControlValueAccessor, NgControl, FormsModule } from '@angular/forms';
import { coerceBooleanProperty } from '@angular/cdk/coercion';

@Component({
    selector: 'app-input',
    templateUrl: './input.component.html',
    styleUrls: ['./input.component.scss'],
    standalone: true,
    imports: [FormsModule],
})
export class InputComponent implements ControlValueAccessor {
  @Input() type: string = 'text';
  @Input() errorMessage: string;
  @Input() formControlName: string;
  private _noTitle: boolean;
  @Input()
  get noTitle() {
    return this._noTitle;
  }
  set noTitle(value: any) {
    this._noTitle = coerceBooleanProperty(value);
  }

  value: string;
  disabled = false;

  constructor(@Self() @Optional() private control: NgControl) {
    if (control) {
      control.valueAccessor = this;
    }
  }

  public get invalid(): boolean {
    return this.control ? this.control.invalid && this.control.touched : false;
  }

  public get showError(): boolean {
    if (!this.control) {
      return false;
    }

    const { dirty, touched } = this.control;

    return this.invalid ? dirty || touched : false;
  }
  onChange: any = (value: any) => {};
  onTouched: any = () => {};

  writeValue(obj: any): void {
    this.value = obj;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }
}
