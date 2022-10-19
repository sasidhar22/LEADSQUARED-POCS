package com.lsqconverse.services;

import com.lsqconverse.models.WeatherModel;

public class WeatherService {

    public WeatherModel getWeather(){
        WeatherModel model = new WeatherModel();
        model.setTemperature(24.5f);
        model.setCity("Bangalore");
        return model;
    }
}
