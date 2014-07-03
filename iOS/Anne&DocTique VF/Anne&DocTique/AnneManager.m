//
//  AnneManager.m
//  Anne&DocTique
//
//  Created by Kapi on 01/03/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import "AnneManager.h"
#import "GroupBuilder.h"
#import "AnneCommunicator.h"

@implementation AnneManager
//For Version 2, Use to 
- (void)fetchCountryAtCoordinate:(CLLocationCoordinate2D)coordinate
{
    [self.communicator searchCountryAtCoordinate];
}

#pragma mark - AnneCommunicatorDelegate

- (void)receivedGroupsJSON:(NSData *)objectNotation
{
    NSError *error = nil;
    NSArray *groups = [GroupBuilder groupsFromJSON:objectNotation error:&error];
    
    if (error != nil) {
        [self.delegate fetchingCountryFailedWithError:error];
        
    } else {
        [self.delegate didReceiveGroup:groups];
    }
}

- (void)fetchingCountryFailedWithError:(NSError *)error
{
    [self.delegate fetchingCountryFailedWithError:error];
}
@end
