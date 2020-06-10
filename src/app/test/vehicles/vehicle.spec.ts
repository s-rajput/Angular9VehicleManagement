 
import {VehicleService} from './../../StateManagement/services/vechicle.service';
import { Injector } from '@angular/core';
import { async, TestBed } from '@angular/core/testing'; 
import { VehicleTypes } from 'src/app/StateManagement/models/vehicle.model';

 
  
describe('ValueService', () => { 
    
    let service: VehicleService;

    let Spy1: jasmine.SpyObj<Injector>;
    let httpClientSpy = jasmine.createSpyObj('HttpClient', ['get', 'post']);


    beforeEach(() => {

    const spy = jasmine.createSpyObj('VehicleService', ['getValue']);

    TestBed.configureTestingModule({ providers: [VehicleService ,  { provide: VehicleService, useValue: spy }]  });
 
    service = TestBed.inject(VehicleService); 

    Spy1 = TestBed.inject(Injector) as jasmine.SpyObj<Injector>;
 

    });
    
    describe('Service: Vehicleservice', () => {

        beforeEach(() => {
          httpClientSpy = jasmine.createSpyObj('HttpClient', ['get', 'post']);
          service = new VehicleService(Spy1,<any> httpClientSpy);
        });
      
            
        it('#getVehicleType should return valid value', () => { 

                expect(service.getVehicleType('Car')).toBe(VehicleTypes.CAR); 
        });
       
        it('#getAllVehicles should be called and return observable',
                (done: DoneFn) => {
                service.getAllVehicles().subscribe(value => {
                        expect(value).toHaveBeenCalled();
                        done();
                });
        });
        
        it('#addVehicle should be called and return observable',
            (done: DoneFn) => {
                    service.addVehicle(null).subscribe(value => {
                    expect(value).toHaveBeenCalled();
                    done();
                    });

        });

        
    });   

  
});