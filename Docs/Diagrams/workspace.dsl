workspace "System do rozpoznawania gestów języka migowego ASL" {
    model {
        userActor = person "Użytkownik"
        kinect = softwareSystem "Urządzenie Kinect" {
            tags "Hardware"
        }
        mediaPipe = softwareSystem "MediaPipe Solutions" {
            tags "Framework"
        }
        system = softwareSystem "System rozpoznawania gestów języka migowego ASL" "" {
            desktopApp = container "GestureRecognitionKinectApp" {
                description "\nAplikacja Desktop .NET (WPF)"
                tags "App"

                desktopAppCore = component "GestureRecognitionKinectApp" {
                    description "\nPodstawowa funkcjonalność\naplikacji Desktop"
                    tags "AppComponent"
                }
                kinectClient = component "KinectClient" {
                    description "\nModuł klienta realizującego komunikację z KinectServer w oparciu o mechanizm Named Pipes"
                }
                mediaPipeBodyTrackingWebSocketClient = component "MediaPipe\nBodyTracking\nWebSocketClient" {
                    description "\nModuł klienta przeprowadzającego komunikację z MediaPipe\nBodyTrackingWebSocketServer, korzystając z protokołu WebSocket"
                }
                replay = component "Replay" {
                    description "\nObiekt odtwarzający nagranie gestu"
                }
                recorder = component "Recorder" {
                    description "\nObiekt serializujący nagranie gestu wraz z informacją o położeniu punktów charakterystycznych"
                }
                gestureRecognitionFeaturesManager = component "GestureRecognition\nFeaturesManager" {
                    description "\nModuł wyznaczający wartości cech opisujących wykonanie danego gestu"
                }
                gestureRecognitionManager = component "GestureRecognition\nManager" {
                    description "\nZarządca procesu rozpoznawania gestu"
                }
                gestureRecognitionModelWrapper = component "GestureRecognition\nModelWrapper" {
                    description "\nUchwyt do klasyfikatora gestów"
                }
            }

            localFilesSystem = container "Lokalny system plików" { 
                tags "Files"
            }

            kinectServer = container "KinectServer" {
                description "\nSerwer .NET"
                tags "Server"
            }

            mediaPipeServer = container "MediaPipeBodyTracking\nWebSocketServer" { 
                description "\nSerwer Python"
                tags "Server"
            }
        }

        userActor -> system "Wykonuje gesty,\nkorzysta z aplikacji"
        system -> kinect "Pobiera obraz RGB\ni dane dotyczące pozycji sylwetki użytkownika" 
        system -> mediaPipe "Uruchamia analizę obrazu pod kątem śledzenia ruchu użytkownika" 

        userActor -> desktopApp "Korzysta z aplikacji"
        desktopApp -> kinectServer "Żąda danych\nz urządzenia Kinect" 
        desktopApp -> mediaPipeServer "Żąda analizy obrazu\npod kątem śledzenia\nruchu użytkownika"
        desktopApp -> localFilesSystem "Zapisuje oraz odczytuje nagrania gestów,\nładuje modele ML"
        kinectServer -> kinect "Pobiera obraz RGB\ni dane dotyczące pozycji sylwetki użytkownika"
        mediaPipeServer -> mediaPipe "Uruchamia analizę obrazu pod kątem śledzenia ruchu użytkownika"

        desktopAppCore -> kinectClient "Używa do komunikacji\nz KinectServer"
        desktopAppCore -> mediaPipeBodyTrackingWebSocketClient "Używa do komunikacji\nz MediaPipe\nBodyTracking\nWebSocketServer"
        kinectClient -> kinectServer "Żąda danych\nz urządzenia Kinect"
        mediaPipeBodyTrackingWebSocketClient -> mediaPipeServer "Żąda analizy obrazu\npod kątem śledzenia\nruchu użytkownika"
        desktopAppCore -> recorder "Wykorzystuje do zapisu nagrania gestu"
        desktopAppCore -> replay "Stosuje do odtworzenia nagrania gestu"
        recorder -> localFilesSystem "Zapisuje nagranie gestu do pliku"
        replay -> localFilesSystem "Odtwarza nagranie gestu z pliku"
        desktopAppCore -> gestureRecognitionFeaturesManager "Używa do wyliczenia wartości cech gestu"
        desktopAppCore -> gestureRecognitionManager "Wykorzystuje do realizacji predykcji gestu"
        gestureRecognitionManager -> gestureRecognitionModelWrapper "Żąda uruchomienia procesu klasyfikacji gestu"

        gestureRecognitionModelWrapper -> localFilesSystem "Zapisuje oraz ładuje modele klasyfikatorów gestów"
    }
    views {
        systemContext system "C1" "Diagram kontekstu systemu" {
            include userActor
            include system
            include kinect
            include mediaPipe
            autoLayout tb 500 300
        }
        container system "C2" "Diagram kontenerów" {
            include userActor
            include desktopApp
            include kinectServer
            include mediaPipeServer
            include localFilesSystem
            include kinect
            include mediaPipe
            autoLayout tb 500 300
        }
        component desktopApp "C3_1" "Diagram komponentów aplikacji desktop część 1" {
            include desktopAppCore
            include kinectClient
            include mediaPipeBodyTrackingWebSocketClient
            include mediaPipeServer
            include kinectServer
            autolayout tb 500 300
        }
        component desktopApp "C3_2" "Diagram komponentów aplikacji desktop część 2" {
            include desktopAppCore
            include recorder
            include replay
            include gestureRecognitionFeaturesManager
            include localFilesSystem
            autolayout tb 500 300
        }
        component desktopApp "C3_3" "Diagram komponentów aplikacji desktop część 3" {
            include desktopAppCore
            include gestureRecognitionFeaturesManager
            include gestureRecognitionManager
            include gestureRecognitionModelWrapper
            include localFilesSystem
            autolayout tb 500 300
        }


        styles {
            element "Person" {
                background "#ffffff"
                color "#2e7d32"
                stroke "#2e7d32"
                strokeWidth 8
                shape "Person"
                width 650
                height 450
                fontSize 52
                metadata false
            }
            element "Software System" {
                background "#ffffff"
                color "#051b57"
                stroke "#051b57"
                strokeWidth 8
                width 1000
                height 600
                fontSize 52
                metadata false
            }
            element "Container" {
                background "#ffffff"
                color "#064c92"
                stroke "#064c92"
                strokeWidth 8
                width 1000
                height 600
                fontSize 52
                metadata false
            }
            element "App" {
                background "#ffffff"
                color "#064c92"
                stroke "#064c92"
                strokeWidth 8
                shape "WebBrowser"
                width 1000
                height 600
                fontSize 52
                metadata false
            }
            element "Server"{
                background "#ffffff"
                color "#064c92"
                stroke "#064c92"
                strokeWidth 8
                shape "Box"
                width 1000
                height 600
                fontSize 52
                metadata false
            }
            element "Component" {
                background "#ffffff"
                color "#0a78d3"
                stroke "#0a78d3"
                strokeWidth 8
                shape "Component"
                width 1000
                height 600
                fontSize 52
                metadata false
            }
            element "AppComponent" {
                background "#ffffff"
                color "#064c92"
                stroke "#064c92"
                strokeWidth 8
                shape "WebBrowser"
                width 1000
                height 600
                fontSize 52
                metadata false
            }
            element "Hardware" {
                background "#ffffff"
                color "#3e3e3e"
                stroke "#3e3e3e"
                strokeWidth 8
                shape "RoundedBox"
                width 1000
                height 600
                fontSize 52
                metadata false
            }
            element "Framework" {
                background "#ffffff"
                color "#bd0817"
                stroke "#bd0817"
                strokeWidth 8
                shape "RoundedBox"
                width 1000
                height 600
                fontSize 52
                metadata false
            }
            element "Files" {
                background "#ffffff"
                color "#FF7700"
                stroke "#FF7700"
                strokeWidth 8
                shape "Folder"
                width 1000
                height 600
                fontSize 52
                metadata false
            }
            relationship "Relationship" {
                color "#333333"
                thickness 4
                width 600
                dashed true
                routing Direct
                fontSize 52
                opacity 100
                position 45
            }
        }

        terminology {
            person ""
            softwareSystem "System"
            container "Aplikacja"
            component ""
            deploymentNode ""
            infrastructureNode ""
            relationship ""
        }
    }
}
