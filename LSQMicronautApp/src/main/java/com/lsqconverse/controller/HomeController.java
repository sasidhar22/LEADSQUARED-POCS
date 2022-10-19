package com.lsqconverse.controller;

import io.micronaut.http.MediaType;
import io.micronaut.http.annotation.Controller;
import io.micronaut.http.annotation.Get;

@Controller("/")
public class HomeController {

    @Get(uri = "/", produces = MediaType.TEXT_PLAIN)
    public String index() {
        return "Welcome to api";
    }
}
