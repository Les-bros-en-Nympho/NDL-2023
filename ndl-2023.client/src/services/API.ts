export class API {
    private static instance: API; // The singleton instance
    private static readonly BASE_URL = "/api"; // Check vite.config.ts -> server proxy

    /**
     * The constructor is private to prevent the creation of multiple instances
     */
    private constructor() {}

    /**
     * The getInstance method returns the singleton instance of the API class
     * @returns The singleton instance of the API class
     */
    static getInstance(): API {
        if (!API.instance) {
            API.instance = new API();
        }
        return API.instance;
    }

    /**
     * The get method sends a GET request to the API
     * @param path  The path of the API endpoint
     * @returns The response of the API
     */
    async get(path: string): Promise<JSON> {
        const response = await fetch(`${API.BASE_URL}${path}`);
        return await response.json();
    }

    /**
     * The post method sends a POST request to the API
     * @param path The path of the API endpoint
     * @param body The body of the request
     * @returns The response of the API
     */
    async post(path: string, body: { [key: string]: any }): Promise<{ [key: string]: any }> {
        const response = await fetch(`${API.BASE_URL}${path}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body),
        });
        return await response.json();
    }

    /**
     * The put method sends a PUT request to the API
     * @param path The path of the API endpoint
     * @param body The body of the request
     * @returns The response of the API
     */
    async put(path: string, body: JSON): Promise<JSON> {
        const response = await fetch(`${API.BASE_URL}${path}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body),
        });
        return await response.json();
    }

    /**
     * The delete method sends a DELETE request to the API
     * @param path The path of the API endpoint
     * @returns The response of the API
     */
    async delete(path: string): Promise<JSON> {
        const response = await fetch(`${API.BASE_URL}${path}`, {
            method: 'DELETE',
        });
        return await response.json();
    }
}