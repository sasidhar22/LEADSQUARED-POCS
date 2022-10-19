package com.lsqconverse.controller;

import com.lsqconverse.models.WeatherModel;
import com.lsqconverse.services.WeatherService;
import io.micronaut.http.MediaType;
import io.micronaut.http.annotation.Controller;
import io.micronaut.http.annotation.Get;

@Controller("/weather")
public class WeatherController {

    @Get(uri = "/")
    public WeatherModel temperature(){
        WeatherService service = new WeatherService();
        return service.getWeather();
    }
}
