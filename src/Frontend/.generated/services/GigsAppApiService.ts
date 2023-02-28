/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Gig } from '../models/Gig';
import type { GigDto } from '../models/GigDto';
import type { NewGigCreated } from '../models/NewGigCreated';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class GigsAppApiService {

    /**
     * @returns Gig Success
     * @throws ApiError
     */
    public static getApiV1Gigs(): CancelablePromise<Array<Gig>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/v1/gigs',
            errors: {
                400: `Bad Request`,
                500: `Internal Server Error`,
            },
        });
    }

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static deleteApiV1Gigs(): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/v1/gigs',
            errors: {
                400: `Bad Request`,
                500: `Internal Server Error`,
            },
        });
    }

    /**
     * @param id
     * @returns Gig Success
     * @throws ApiError
     */
    public static getApiV1Gig(
        id: string,
    ): CancelablePromise<Gig> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/v1/gig/{id}',
            path: {
                'id': id,
            },
            errors: {
                400: `Bad Request`,
                500: `Internal Server Error`,
            },
        });
    }

    /**
     * @param requestBody
     * @returns GigDto Success
     * @throws ApiError
     */
    public static postApiV1Gig(
        requestBody: NewGigCreated,
    ): CancelablePromise<GigDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/v1/gig',
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                400: `Bad Request`,
                500: `Internal Server Error`,
            },
        });
    }

}
