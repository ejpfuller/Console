//
//  main.c
//  CTest
//
//  Created by Ethan Fuller on 30/12/2019.
//  Copyright © 2019 Ethan Fuller. All rights reserved.
//

#include <stdio.h>
#include <string.h>
#include <curl/curl.h>

void Pointer_action(void);
void Get_HTTP(void);

int main(int argc, const char * argv[])
{
    Get_HTTP();
    Pointer_action();
    return 0;
}

// ------   Playing with pointers   -----
void Pointer_action (void)
{
    int num = 0;
    char word[20];
    
    //     INPUT     //
    printf("Please enter number:");
    scanf("%d",&num);
    
    printf("Please enter a sentence:");
    scanf("%s", word);
    
    //      OUTPUT     //
    int *pnum = &num;
    printf("\n\nThe number entered was: %d \n", *pnum);
    printf("This is the address for pnum: %p \nThis is the address for num: %p \n\n", &pnum, &num);
    
    long leng = strlen(word);
    printf("The string entered was: %s \nThe address of first letter is:%p \nThe address of last letter is:%p\n", word,&word[0], &word[leng-1]);
    
    printf("First letter: %c \nLast Letter: %c \n\n", word[0],word[leng-1]);
}

    ///   HTTP GET REQUEST       ///
void Get_HTTP (void)
{
    printf (curl_easy_setopt(CURL *curl, CURLOPT_URL,"https://data.police.uk/api/forces");
}
