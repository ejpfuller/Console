#include <stdio.h>
#include <time.h>

int main () {
    time_t rawtime;
    struct tm *info;
    time (&rawtime);
    info = localtime (&rawtime);
    
    printf("hello world! The current local time and date is: %s", asctime (info));
}